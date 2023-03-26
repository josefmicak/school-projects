CREATE OR ALTER PROCEDURE sumarizace_aktivity_zakazniku
AS
BEGIN

BEGIN TRANSACTION
BEGIN TRY

UPDATE Zakaznik
SET neaktivni = CASE
WHEN id_zakaznika IN
(SELECT Zakaznik.id_zakaznika
FROM Zakaznik
JOIN Objednavka ON Objednavka.id_zakaznika = Zakaznik.id_zakaznika
GROUP BY Zakaznik.id_zakaznika
HAVING MAX(Objednavka.datum_vytvoreni) < GETDATE() - 6) THEN 'Y'
ELSE neaktivni
END,
zrusen = CASE
WHEN id_zakaznika IN
(SELECT Zakaznik.id_zakaznika
FROM Zakaznik
JOIN Objednavka ON Objednavka.id_zakaznika = Zakaznik.id_zakaznika
GROUP BY Zakaznik.id_zakaznika
HAVING MAX(Objednavka.datum_vytvoreni) < GETDATE() - 12) THEN 'Y'
ELSE zrusen
END
WHERE id_zakaznika IN
(SELECT Zakaznik.id_zakaznika
FROM Zakaznik
JOIN Objednavka ON Objednavka.id_zakaznika = Zakaznik.id_zakaznika GROUP BY Zakaznik.id_zakaznika
HAVING (MAX(Objednavka.datum_vytvoreni) < GETDATE() - 6)
OR (MAX(Objednavka.datum_vytvoreni) < GETDATE() - 12))

INSERT INTO ZakaznikStatistika(datum_statistiky, pocet_neaktivnich, pocet_zrusenych)
VALUES (GETDATE(), (SELECT COUNT(*) FROM Zakaznik WHERE neaktivni = 'Y'), (SELECT COUNT(*) FROM Zakaznik WHERE zrusen = 'Y'))

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
END