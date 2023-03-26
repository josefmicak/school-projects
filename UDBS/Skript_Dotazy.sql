--1. Skupina

/*1;1;1;Vypise prumerny pocet ujetych kilomteru vozidel*/
SELECT AVG(pocet_ujetych_km) AS 'prumerny pocet ujetych km'
FROM Vozidlo

/*1;2;1;Vypise celkovou hodnotu vsech objednavek*/
SELECT SUM(cena) AS 'celkova hodnota objednavek'
FROM objednavka

/*1;3;4;Vypise rozvazky podle casu dokonceni rozvazky serazene od nejpozdnejsi po nejdrivejsi*/
SELECT id_rozvazky, DATEDIFF(MINUTE, cas_odjezdu, cas_prijezdu) AS 'pocet minut'
FROM Rozvazka
ORDER BY DATEDIFF(MINUTE, cas_odjezdu, cas_prijezdu) DESC

/*1;4;7;Vypise objednavky v hodnote vyssi nez 250 serazene od nejlevnejsi po nejdrazsi*/
SELECT id_objednavky, cena
FROM Objednavka
WHERE cena > 250
ORDER BY cena

--2. skupina

/*2;1;2; Vypise vsechny zamestnance muzskeho pohlavi, kteri pracuji na pozici kuchar nebo ridic*/
SELECT id_zamestnance, jmeno, prijmeni
FROM zamestnanec
WHERE pohlavi = 'M' AND (pozice = 'Kuchar' OR pozice = 'Ridic')

/*2;2;3;Vypise vsechna hodnoceni, ktera nebyla podana na zamestnance pracujici na pozici ridic*/
SELECT hodnoceni.id_hodnoceni, hodnoceni.id_zamestnance, hodnoceni.hodnoceni, zamestnanec.pozice
FROM hodnoceni
	JOIN zamestnanec ON hodnoceni.id_zamestnance = zamestnanec.id_zamestnance
WHERE pozice != 'Ridic'

/*2;3;8;Vypise vsechny zakazniky, jejichz jmeno nezacina na J*/
SELECT id_zakaznika, jmeno, prijmeni
FROM zakaznik
WHERE jmeno NOT LIKE 'J%'

/*2;4;2;Vypise vsechny rozvazky, ktere trvaly dele nez 60 minut*/
SELECT id_rozvazky, cas_odjezdu, cas_prijezdu
FROM rozvazka
WHERE DATEDIFF(MINUTE, cas_odjezdu, cas_prijezdu) > 60

--3. skupina

/*3;1;5;Vypiste vsechny zamestnance, na ktere nebyla podana stiznost pomoci IN*/
SELECT id_zamestnance
FROM zamestnanec
WHERE id_zamestnance NOT IN
	(
		SELECT id_zamestnance
		FROM stiznost
	)

/*3;2;5;Vypiste vsechny zamestnance, na ktere nebyla podana stiznost pomoci ALL*/
SELECT id_zamestnance
FROM zamestnanec
WHERE id_zamestnance != ALL
	(
		SELECT id_zamestnance
		FROM stiznost
	)

/*3;3;5;Vypiste vsechny zamestnance, na ktere nebyla podana stiznost pomoci EXISTS*/
SELECT id_zamestnance
FROM zamestnanec za
WHERE NOT EXISTS
	(
		SELECT id_zamestnance
		FROM stiznost st
		WHERE st.id_zamestnance = za.id_zamestnance
	)

/*3;3;5;Vypiste vsechny zamestnance, na ktere nebyla podana stiznost pomoci EXCEPT*/
SELECT id_zamestnance
FROM zamestnanec
	EXCEPT
	(
		SELECT id_zamestnance
		FROM stiznost
	)

--4. Skupina

/*4;1;3;Vypise zamestnancum pocet objednavek, o ktere se postarali*/
SELECT zamestnanec.id_zamestnance, zamestnanec.jmeno, zamestnanec.prijmeni, COUNT(objednavka.id_objednavky) AS 'pocet zpracovanych objednavek'
FROM zamestnanec
	JOIN objednavka ON objednavka.id_zamestnance = zamestnanec.id_zamestnance
GROUP BY zamestnanec.id_zamestnance, zamestnanec.jmeno, zamestnanec.prijmeni

/*4;2;4;Vypise pocet objednavek, ktery byl v rozvazce zahrnut*/
SELECT rozvazka.id_rozvazky, COUNT(objednavka.id_objednavky) AS 'pocet objednavek'
FROM rozvazka
	JOIN objednavka ON rozvazka.id_rozvazky = objednavka.id_rozvazky
GROUP BY rozvazka.id_rozvazky 

/*4;3;3;Vypise pocet hodnoceni, ktera zakaznici napsali*/
SELECT zakaznik.id_zakaznika, zakaznik.jmeno, zakaznik.prijmeni, COUNT(hodnoceni.id_hodnoceni) AS 'pocet hodnoceni'
FROM zakaznik
	JOIN hodnoceni ON zakaznik.id_zakaznika = hodnoceni.id_zakaznika
GROUP BY zakaznik.id_zakaznika, zakaznik.jmeno, zakaznik.prijmeni

/*4;4;2;Vypise vsechna vozidla, ktera byla vyuzita pro rozvezeni vice nez 1 rozvazky*/
SELECT rozvazka.id_vozidla, COUNT(id_rozvazky) AS 'pocet rozvazek'
FROM rozvazka
GROUP BY rozvazka.id_vozidla
HAVING COUNT(id_rozvazky) > 1

--5. Skupina

/*5;1;8;Vypise vsechny zakazniky, kteri vytvorili nejakou objednavku*/
SELECT DISTINCT za.id_zakaznika, za.jmeno, za.prijmeni
FROM zakaznik za
JOIN objednavka ob ON za.id_zakaznika = ob.id_zakaznika

/*5;2;8;Vypise vsechny zakazniky, kteri vytvorili nejakou objednavku pomoci IN*/
SELECT DISTINCT za.id_zakaznika, za.jmeno, za.prijmeni
FROM zakaznik za
WHERE za.id_zakaznika IN
(
	SELECT ob.id_zakaznika
	FROM objednavka ob
)

/*5;3;6;Vypise pro kazdeho zamestnance pocet rozvazek, o ktere se postaral*/
SELECT DISTINCT zamestnanec.id_zamestnance, zamestnanec.jmeno, zamestnanec.prijmeni, COUNT(rozvazka.id_rozvazky) AS 'pocet rozvazek'
FROM zamestnanec
	LEFT JOIN rozvazka ON zamestnanec.id_zamestnance = rozvazka.id_zamestnance
GROUP BY zamestnanec.id_zamestnance, zamestnanec.jmeno, zamestnanec.prijmeni

/*5;4;4;Vypiste pocet objednavek pro kazdeho zakaznika, jehoz jmeno zacina na P*/
SELECT zakaznik.id_zakaznika, zakaznik.jmeno, zakaznik.prijmeni, COUNT(objednavka.id_objednavky) AS 'pocet objednavek'
FROM zakaznik
	LEFT JOIN objednavka ON zakaznik.id_zakaznika = objednavka.id_zakaznika
WHERE zakaznik.jmeno LIKE 'P%'
GROUP BY zakaznik.id_zakaznika, zakaznik.jmeno, zakaznik.prijmeni

--6. Skupina

/*6;1;3;Pro kazdeho zakaznika, ktery nekdy vytvoril alespon jednu objednavku a alespon jedno hodnoceni, vypise datum vytvoreni jeho posledni objednavky*/

SELECT DISTINCT zakaznik.id_zakaznika, zakaznik.jmeno, zakaznik.prijmeni, ob1.datum_vytvoreni
FROM zakaznik
	JOIN objednavka ob1 ON ob1.id_zakaznika = zakaznik.id_zakaznika
WHERE ob1.datum_vytvoreni = 
(
	SELECT MAX(datum_vytvoreni)
	FROM objednavka ob2
	WHERE ob1.id_zakaznika = ob2.id_zakaznika
)
AND zakaznik.id_zakaznika IN
(
	SELECT hodnoceni.id_zakaznika
	FROM hodnoceni
)


/*6;2;2;Vypise rozvazky, u nichz je hodnota jejich objednavek vyssi nez prumerna hodnota objednavek rozvazky*/
WITH t AS
(
	SELECT rozvazka.id_rozvazky, SUM(cena) AS pocet
	FROM rozvazka
		JOIN objednavka ON rozvazka.id_rozvazky = objednavka.id_rozvazky
	GROUP BY rozvazka.id_rozvazky
)
SELECT t.id_rozvazky, SUM(cena) 'hodnota objednavek'
FROM t
	JOIN objednavka ON t.id_rozvazky = objednavka.id_rozvazky
WHERE pocet > (SELECT AVG(pocet) FROM t)
GROUP BY t.id_rozvazky


