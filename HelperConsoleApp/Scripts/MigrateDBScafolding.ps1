<#
.SYNOPSIS
    Copies the Persistence folder from a temp scaffolding project to the Infrastructure project
    and ensures the files are included in the .csproj.

.PARAMETER TempProjectPath
    Path to the temporary scaffolding project (e.g., ../EfScaffoldTemp)

.PARAMETER InfrastructureProjectPath
    Path to the Infrastructure project (e.g., ../GraphQL.Infrastructure)
#>

param(
    [string]$TempProjectPath = "HelperConsoleApp",
    [string]$InfrastructureProjectPath = "GraphQL.Infrastructure"
)

# Paths
$sourcePersistence = Join-Path $TempProjectPath "Persistence"
$destPersistence   = Join-Path $InfrastructureProjectPath "Persistence/Sqlserver"
$csprojPath        = Get-ChildItem $InfrastructureProjectPath -Filter *.csproj | Select-Object -First 1

if (-not (Test-Path $sourcePersistence)) {
    Write-Error "Source Persistence folder not found: $sourcePersistence"
    exit 1
}

# Remove existing destination folder if exists
if (Test-Path $destPersistence) {
    Write-Host "Removing existing Persistence folder in Infrastructure..."
    Remove-Item $destPersistence -Recurse -Force
}

# Copy folder
Write-Host "Copying Persistence folder from temp project to Infrastructure..."
Copy-Item $sourcePersistence $destPersistence -Recurse

# Include files in .csproj
Write-Host "Ensuring files are included in $csprojPath..."
[xml]$csprojXml = Get-Content $csprojPath.FullName

# Find or create ItemGroup for Compile
$itemGroup = $csprojXml.Project.ItemGroup | Where-Object { $_.Compile } | Select-Object -First 1
if (-not $itemGroup) {
    $itemGroup = $csprojXml.CreateElement("ItemGroup")
    $csprojXml.Project.AppendChild($itemGroup) | Out-Null
}

# Remove any existing Compile Include for Persistence (to avoid duplicates)
$itemGroup.Compile | Where-Object { $_.Include -like "Persistence\**\*.cs" } | ForEach-Object {
    $itemGroup.RemoveChild($_) | Out-Null
}

# Add all .cs files under Persistence
$csFiles = Get-ChildItem $destPersistence -Recurse -Filter *.cs
foreach ($file in $csFiles) {
    $relativePath = $file.FullName.Substring($InfrastructureProjectPath.Length + 1) -replace "\\", "\"
    $compileElement = $csprojXml.CreateElement("Compile")
    $compileElement.SetAttribute("Include", $relativePath)
    $itemGroup.AppendChild($compileElement) | Out-Null
}

# Save updated .csproj
$csprojXml.Save($csprojPath.FullName)
Write-Host "Persistence folder copied and included successfully!"
