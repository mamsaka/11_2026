PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS REQUEST;
DROP TABLE IF EXISTS EMPLOYEE;
DROP TABLE IF EXISTS ADMIN;
DROP TABLE IF EXISTS SPECIALIST;
DROP TABLE IF EXISTS EQUIPMENT_TYPE;
DROP TABLE IF EXISTS STATUS;

CREATE TABLE EMPLOYEE (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name   TEXT NOT NULL,
    position    TEXT,
    department  TEXT,
    login       TEXT NOT NULL UNIQUE,
    password    TEXT NOT NULL,
    created_at  TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ADMIN (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name   TEXT NOT NULL,
    login       TEXT NOT NULL UNIQUE,
    password    TEXT NOT NULL,
    created_at  TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE SPECIALIST (
    id              INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name       TEXT NOT NULL,
    specialization  TEXT,
    login           TEXT NOT NULL UNIQUE,
    password        TEXT NOT NULL,
    is_active       INTEGER NOT NULL DEFAULT 1 CHECK (is_active IN (0, 1)),
    created_at      TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE EQUIPMENT_TYPE (
    id           INTEGER PRIMARY KEY AUTOINCREMENT,
    name         TEXT NOT NULL UNIQUE,
    description  TEXT
);

CREATE TABLE STATUS (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    name        TEXT NOT NULL UNIQUE,
    sort_order  INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE REQUEST (
    id                   INTEGER PRIMARY KEY AUTOINCREMENT,
    employee_id          INTEGER NOT NULL REFERENCES EMPLOYEE (id) ON DELETE RESTRICT,
    specialist_id        INTEGER REFERENCES SPECIALIST (id) ON DELETE SET NULL,
    equipment_type_id    INTEGER NOT NULL REFERENCES EQUIPMENT_TYPE (id) ON DELETE RESTRICT,
    status_id            INTEGER NOT NULL REFERENCES STATUS (id) ON DELETE RESTRICT,
    problem_description  TEXT NOT NULL,
    created_at           TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at           TEXT,
    completed_at         TEXT
);

CREATE INDEX idx_request_employee ON REQUEST (employee_id);
CREATE INDEX idx_request_specialist ON REQUEST (specialist_id);
CREATE INDEX idx_request_status ON REQUEST (status_id);

-- Справочник статусов
INSERT INTO STATUS (name, sort_order) VALUES
    ('Новая', 1),
    ('В работе', 2),
    ('Выполнена', 3);

-- Справочник типов оборудования
INSERT INTO EQUIPMENT_TYPE (name, description) VALUES
    ('ПК', 'Персональный компьютер'),
    ('Принтер', 'Лазерный или струйный принтер'),
    ('Сканер', 'Планшетный сканер'),
    ('МФУ', 'Многофункциональное устройство');

-- Пользователи
INSERT INTO EMPLOYEE (full_name, position, department, login, password) VALUES
    ('Иванов Иван Иванович', 'Бухгалтер', 'Бухгалтерия', 'ivanov', 'ivanov123'),
    ('Петрова Анна Сергеевна', 'Менеджер', 'Отдел продаж', 'petrova', 'petrova123');

INSERT INTO ADMIN (full_name, login, password) VALUES
    ('Смирнов Алексей Викторович', 'admin', 'admin123');

INSERT INTO SPECIALIST (full_name, specialization, login, password, is_active) VALUES
    ('Кузнецов Дмитрий Олегович', 'Системный администратор', 'kuznetsov', 'kuznetsov123', 1),
    ('Соколов Павел Андреевич', 'Техник по ремонту', 'sokolov', 'sokolov123', 1);

-- Тестовые заявки
INSERT INTO REQUEST (employee_id, specialist_id, equipment_type_id, status_id, problem_description, created_at, updated_at, completed_at) VALUES
    (1, 1, 1, 2, 'Не включается компьютер, индикатор питания не горит.', '2026-11-20 09:15:00', '2026-11-20 10:05:00', NULL),
    (2, NULL, 2, 1, 'Принтер заминает бумагу при печати.', '2026-11-21 11:30:00', NULL, NULL),
    (1, 2, 4, 3, 'МФУ не сканирует, выдаёт ошибку драйвера.', '2026-11-19 14:00:00', '2026-11-19 15:20:00', '2026-11-19 16:45:00');
