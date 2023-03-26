CREATE OR ALTER PROCEDURE kontrola_dostupnosti_zamestnance @id_zamestnance INT
AS 
DECLARE @pocet_rozvazek INT
	
SELECT @pocet_rozvazek = COUNT(*)
FROM Rozvazka
WHERE cas_prijezdu IS NULL
AND cas_odjezdu IS NOT NULL
AND id_zamestnance = @id_zamestnance;

IF @pocet_rozvazek > 0
	SELECT Zamestnanec.id_zamestnance, Zamestnanec.jmeno, Zamestnanec.prijmeni, MAX(Rozvazka.cas_odjezdu) AS 'cas odjezdu', MAX(Rozvazka.cas_prijezdu) AS 'cas prijezdu'
	FROM Zamestnanec
	JOIN Rozvazka ON Rozvazka.id_zamestnance = Zamestnanec.id_zamestnance
	WHERE Zamestnanec.id_zamestnance NOT IN
	(
	SELECT Rozvazka.id_zamestnance
	FROM Rozvazka
	WHERE cas_prijezdu IS NULL
	AND cas_odjezdu IS NOT NULL
	)
	AND Zamestnanec.id_zamestnance NOT IN
	(
	SELECT Zamestnanec.id_zamestnance
	FROM Zamestnanec
	WHERE Zamestnanec.vyhozen = 'Y'
	)
	GROUP BY Zamestnanec.id_zamestnance, Zamestnanec.jmeno, Zamestnanec.prijmeni
	ORDER BY MAX(Rozvazka.cas_prijezdu) DESC