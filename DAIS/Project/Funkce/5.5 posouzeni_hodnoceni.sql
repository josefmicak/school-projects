CREATE OR ALTER PROCEDURE posouzeni_hodnoceni
AS
BEGIN

BEGIN TRANSACTION
BEGIN TRY

UPDATE Zamestnanec
SET plat = plat * 1.1
WHERE id_zamestnance IN
(
SELECT id_zamestnance
FROM Hodnoceni
GROUP BY id_zamestnance
HAVING COUNT(*) > 4 AND AVG(hodnoceni) > 9
)

UPDATE Zamestnanec
SET plat = plat * 0.9
WHERE id_zamestnance IN
(
SELECT id_zamestnance
FROM Hodnoceni
GROUP BY id_zamestnance
HAVING COUNT(*) > 4 AND AVG(hodnoceni) < 3
)

UPDATE Zamestnanec
SET vyhozen = 'Y'
WHERE id_zamestnance IN
(
SELECT id_zamestnance
FROM Hodnoceni
GROUP BY id_zamestnance
HAVING COUNT(*) > 4 AND AVG(hodnoceni) < 1.5
)

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
END