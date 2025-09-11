-- Tabela Edituri
CREATE TABLE Edituri (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(100) NOT NULL UNIQUE
)

-- Tabela Autori  
CREATE TABLE Autori (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(100) NOT NULL UNIQUE
)

-- Tabela Carti (modificată)
CREATE TABLE Carti (
    Id INT PRIMARY KEY IDENTITY(100000,1),
    Titlu NVARCHAR(100) NOT NULL,
    AnPublicare INT NOT NULL CHECK (AnPublicare BETWEEN 1445 AND 2025),
    Descriere NVARCHAR(500),
    EdituraId INT FOREIGN KEY REFERENCES Edituri(Id)
)

-- Tabela de legătură CartiAutori (many-to-many)
CREATE TABLE CartiAutori (
    CarteId INT FOREIGN KEY REFERENCES Carti(Id),
    AutorId INT FOREIGN KEY REFERENCES Autori(Id),
    PRIMARY KEY (CarteId, AutorId)
)

SELECT * FROM Edituri 
SELECT * FROM Autori 
SELECT * FROM Carti 
SELECT * FROM CartiAutori 

-- 1. Golire tabele (în ordinea corectă pentru constrângeri foreign key)
DELETE FROM CartiAutori;    -- Mai întâi tabela de legătură
DELETE FROM Carti;          -- Apoi cărțile
DELETE FROM Autori;         -- Apoi autorii
DELETE FROM Edituri;        -- În final editurile

-- 2. Resetare identity counters (ca ID-urile să înceapă de la 1)
DBCC CHECKIDENT ('CartiAutori', RESEED, 0);
DBCC CHECKIDENT ('Carti', RESEED, 99999);    -- Ca să înceapă de la 100000
DBCC CHECKIDENT ('Autori', RESEED, 0);
DBCC CHECKIDENT ('Edituri', RESEED, 0);

INSERT INTO Edituri (Nume) VALUES
('Humanitas'),
('Nemira'),
('Polirom'), 
('RAO'),
('Litera');

INSERT INTO Autori (Nume) VALUES
('Mircea Eliade'),
('Emil Cioran'),
('Mircea Cărtărescu'),
('George Orwell'),
('Ernest Hemingway'),
('Liviu Rebreanu'),
('Ion Luca Caragiale'),
('Lev Tolstoi'),
('Fyodor Dostoievski');

INSERT INTO Carti (Titlu, AnPublicare, Descriere, EdituraId) VALUES
('Maitreyi', 1933, 'Roman de dragoste indian', 1),
('Pe culmile disperării', 1934, 'Lucrare filosofică', 2),
('Orbitor', 1996, 'Trilogie modernistă', 3),
('1984', 1949, 'Roman distopic emblematic', 4),
('Bătrânul și marea', 1952, 'Roman despre pescuit', 5),
('Ion', 1920, 'Roman țărănesc', 1),
('Enigma Otiliei', 1938, 'Roman social-psihologic', 2),
('O scrisoare pierdută', 1884, 'Comedie satirică', 3),
('Război și pace', 1869, 'Roman istoric epic', 4),
('Crimă și pedeapsă', 1866, 'Roman psihologic', 5),
('Amintiri din copilărie', 1884, 'Operă autobiografică', 1),
('Moara cu noroc', 1881, 'Nuvelă psihologică', 2),
('Frații Karamazov', 1880, 'Roman filosofic', 3),
('Anna Karenina', 1877, 'Roman de dragoste', 4),
('Animal Farm', 1945, 'Satiră politică', 5);

INSERT INTO CartiAutori (CarteId, AutorId) VALUES
(100000, 1),   -- Maitreyi - Mircea Eliade
(100001, 2),   -- Pe culmile disperării - Emil Cioran
(100002, 3),   -- Orbitor - Mircea Cărtărescu
(100003, 4),   -- 1984 - George Orwell
(100004, 5),   -- Bătrânul și marea - Ernest Hemingway
(100005, 6),   -- Ion - Liviu Rebreanu
(100006, 6),   -- Enigma Otiliei - Liviu Rebreanu (presupunere)
(100007, 7),   -- O scrisoare pierdută - Ion Luca Caragiale
(100008, 8),   -- Război și pace - Lev Tolstoi
(100009, 9),   -- Crimă și pedeapsă - Fyodor Dostoievski
(100010, 6),   -- Amintiri din copilărie - Liviu Rebreanu (presupunere)
(100011, 6),   -- Moara cu noroc - Liviu Rebreanu (presupunere)
(100012, 9),   -- Frații Karamazov - Fyodor Dostoievski
(100013, 8),   -- Anna Karenina - Lev Tolstoi
(100014, 4);   -- Animal Farm - George Orwell

-- Verifică toate cărțile cu autorii și editurile
SELECT c.Id, c.Titlu, c.AnPublicare, e.Nume as Editura, a.Nume as Autor
FROM Carti c
INNER JOIN Edituri e ON c.EdituraId = e.Id
INNER JOIN CartiAutori ca ON c.Id = ca.CarteId
INNER JOIN Autori a ON ca.AutorId = a.Id
ORDER BY c.Titlu

SELECT * FROM Carti

DROP TABLE Autori 
SELECT HAS_PERMS_BY_NAME('Biblioteca.dbo.Carti', 'OBJECT', 'DELETE');
USE BibliotecaDB;
GO