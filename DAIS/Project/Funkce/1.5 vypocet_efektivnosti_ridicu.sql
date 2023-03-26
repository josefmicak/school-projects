CREATE OR ALTER PROCEDURE vypocet_efektivnosti_ridicu
AS
SELECT z.id_zamestnance,
	(SELECT COUNT(*) FROM Rozvazka roz WHERE roz.id_zamestnance = z.id_zamestnance) [pocet_rozvazek],
	(SELECT COUNT(obj.id_objednavky) FROM Objednavka obj JOIN Rozvazka roz ON obj.id_rozvazky = roz.id_rozvazky WHERE roz.id_zamestnance = z.id_zamestnance) [pocet_objednavek],
	(
		CAST((SELECT COUNT(obj.id_objednavky) FROM Objednavka obj JOIN Rozvazka ON obj.id_rozvazky = rozvazka.id_rozvazky WHERE rozvazka.id_zamestnance = z.id_zamestnance) AS FLOAT)  /
		(SELECT SUM(DATEDIFF(HOUR, cas_odjezdu, cas_prijezdu)) FROM Rozvazka r WHERE r.id_zamestnance = z.id_zamestnance )
	) [pocet_za_hodinu] 
FROM Zamestnanec z
WHERE EXISTS	
	(SELECT * FROM Rozvazka roz WHERE roz.id_zamestnance = z.id_zamestnance)