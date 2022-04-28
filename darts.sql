--
-- Файл сгенерирован с помощью SQLiteStudio v3.3.3 в Чт апр. 28 18:41:52 2022
--
-- Использованная кодировка текста: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Таблица: countries
CREATE TABLE countries (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING);
INSERT INTO countries (id, name) VALUES (1, 'Russia');
INSERT INTO countries (id, name) VALUES (2, 'Narnia');
INSERT INTO countries (id, name) VALUES (3, 'Poland');
INSERT INTO countries (id, name) VALUES (4, 'Italy');
INSERT INTO countries (id, name) VALUES (5, 'France');
INSERT INTO countries (id, name) VALUES (6, 'Livia');
INSERT INTO countries (id, name) VALUES (7, 'Canada');
INSERT INTO countries (id, name) VALUES (8, 'Germany');
INSERT INTO countries (id, name) VALUES (9, 'USA');
INSERT INTO countries (id, name) VALUES (10, 'Mexico');
INSERT INTO countries (id, name) VALUES (11, 'Sweden');
INSERT INTO countries (id, name) VALUES (12, 'Finland');
INSERT INTO countries (id, name) VALUES (13, 'Ireland');
INSERT INTO countries (id, name) VALUES (14, 'Netherlands');
INSERT INTO countries (id, name) VALUES (15, 'Tokyo');
INSERT INTO countries (id, name) VALUES (16, 'China');
INSERT INTO countries (id, name) VALUES (17, 'Albania');
INSERT INTO countries (id, name) VALUES (18, 'Romania');
INSERT INTO countries (id, name) VALUES (19, 'Greece');

-- Таблица: genders
CREATE TABLE genders (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING);
INSERT INTO genders (id, name) VALUES (1, 'Female');
INSERT INTO genders (id, name) VALUES (2, 'Male');
INSERT INTO genders (id, name) VALUES (3, 'Non-binary');

-- Таблица: matches
CREATE TABLE matches (id INTEGER PRIMARY KEY AUTOINCREMENT, player1_id REFERENCES players (id) ON DELETE CASCADE CHECK (player1_id != player2_id), player2_id REFERENCES players (id) ON DELETE CASCADE CHECK (player1_id != player2_id), score1 INTEGER, score2 INTEGER, tournament_id REFERENCES tournaments (id) ON DELETE CASCADE);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (1, 1, 2, 10, 23, 1);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (2, 1, 2, 300, 23, 1);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (3, 3, 4, 30, 320, 2);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (4, 4, 2, 32, 21, 2);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (5, 3, 4, 12312, 23, 2);
INSERT INTO matches (id, player1_id, player2_id, score1, score2, tournament_id) VALUES (6, 3, 4, 2, 434, 2);

-- Таблица: places
CREATE TABLE places (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING);
INSERT INTO places (id, name) VALUES (1, 'New Arena ');
INSERT INTO places (id, name) VALUES (2, 'Old Arena');

-- Таблица: players
CREATE TABLE players (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name TEXT, age INTEGER, country_id REFERENCES countries (id) ON DELETE SET NULL, gender_id REFERENCES genders (id) ON DELETE SET NULL);
INSERT INTO players (id, name, age, country_id, gender_id) VALUES (1, 'Ivan', 20, 1, 3);
INSERT INTO players (id, name, age, country_id, gender_id) VALUES (2, 'Peter', 43, 1, 2);
INSERT INTO players (id, name, age, country_id, gender_id) VALUES (3, 'Le Jesul', 30, 5, 2);
INSERT INTO players (id, name, age, country_id, gender_id) VALUES (4, 'Nataly', 19, 3, 1);

-- Таблица: tournaments
CREATE TABLE tournaments (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, time DATETIME, place_id REFERENCES places (id) ON DELETE CASCADE);
INSERT INTO tournaments (id, name, time, place_id) VALUES (1, 'Mega Tournament', '27.04.2022', 1);
INSERT INTO tournaments (id, name, time, place_id) VALUES (2, 'Not That Mega', '28.04.2022', 2);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
