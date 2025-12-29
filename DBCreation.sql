IF OBJECT_ID('comment', 'U') IS NOT NULL DROP TABLE comment;
IF OBJECT_ID('task', 'U') IS NOT NULL DROP TABLE task;
IF OBJECT_ID('project', 'U') IS NOT NULL DROP TABLE project;
IF OBJECT_ID('department', 'U') IS NOT NULL DROP TABLE department;
IF OBJECT_ID('organization', 'U') IS NOT NULL DROP TABLE organization;

GO
CREATE TABLE organization (
    org_id      INT IDENTITY(1,1) PRIMARY KEY,
    org_code    VARCHAR(20) NOT NULL UNIQUE,
    org_name    VARCHAR(100) NOT NULL,
    founded_on  DATE NULL,
    created_at  DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE department (
    dept_id     INT IDENTITY(1,1) PRIMARY KEY,
    org_id      INT NOT NULL,
    dept_code   VARCHAR(20) NULL,
    dept_name   VARCHAR(100) NOT NULL,
    head_email  VARCHAR(100) NULL,
    created_at  DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Department_Organization
        FOREIGN KEY (org_id)
        REFERENCES organization(org_id)
);
GO

CREATE TABLE project (
    project_id      INT IDENTITY(1,1) PRIMARY KEY,
    dept_id         INT NOT NULL,
    project_code    VARCHAR(30) UNIQUE,
    project_name    VARCHAR(150),
    start_date      DATE NULL,
    end_date        DATE NULL,
    budget          DECIMAL(12,2) NULL,
    created_at      DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Project_Department
        FOREIGN KEY (dept_id)
        REFERENCES department(dept_id)
);
GO

CREATE TABLE task (
    task_id         INT IDENTITY(1,1) PRIMARY KEY,
    project_id      INT NOT NULL,
    task_code       VARCHAR(30),
    title           VARCHAR(200),
    description     VARCHAR(MAX) NULL,
    status          VARCHAR(30),
    due_date        DATETIME NULL,
    completed_at    DATETIME NULL,
    created_at      DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Task_Project
        FOREIGN KEY (project_id)
        REFERENCES project(project_id)
);
GO

CREATE TABLE comment (
    comment_id      INT IDENTITY(1,1) PRIMARY KEY,
    task_id         INT NOT NULL,
    author_name     VARCHAR(100),
    comment_text    VARCHAR(MAX) NULL,
    created_at      DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Comment_Task
        FOREIGN KEY (task_id)
        REFERENCES task(task_id)
);
GO

INSERT INTO organization (org_code, org_name, founded_on)
VALUES
('ORG-ALPHA', 'Alpha Technologies', '2010-05-15'),
('ORG-BETA', 'Beta Innovations', NULL);
GO

INSERT INTO department (org_id, dept_code, dept_name, head_email)
VALUES
(1, 'ENG-01', 'Engineering', 'eng_head@alpha.com'),
(1, 'HR-01', 'Human Resources', NULL),
(2, 'ENG-02', 'Product Engineering', 'prod_eng@beta.io');
GO

INSERT INTO project (dept_id, project_code, project_name, start_date, end_date, budget)
VALUES
(1, 'PRJ-ENG-A1', 'GraphQL Migration', '2024-01-01', NULL, 150000.00),
(1, 'PRJ-ENG-A2', 'Legacy System Rewrite', '2023-03-01', '2024-06-30', 300000.00),
(3, 'PRJ-BETA-P1', 'Mobile Platform', '2024-02-15', NULL, NULL);
GO

INSERT INTO task (project_id, task_code, title, description, status, due_date, completed_at)
VALUES
(1, 'TASK-GQL-01', 'Schema Design', 'Design GraphQL schema', 'IN_PROGRESS', '2024-12-01 18:00', NULL),
(1, 'TASK-GQL-02', 'Resolver Implementation', 'Write resolvers', 'PENDING', '2024-12-15 18:00', NULL),
(2, 'TASK-LEG-01', 'Code Refactor', NULL, 'COMPLETED', '2024-03-01 12:00', '2024-02-28 10:30'),
(3, 'TASK-MOB-01', 'UI Wireframes', 'Initial mobile UI sketches', 'IN_PROGRESS', NULL, NULL);
GO

INSERT INTO comment (task_id, author_name, comment_text)
VALUES
(1, 'Alice', 'Initial schema draft completed'),
(1, 'Bob', 'Need to add pagination'),
(3, 'Charlie', 'Refactor looks good'),
(4, 'Dana', NULL);
