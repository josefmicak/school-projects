CREATE OR ALTER PROCEDURE sleva_objednavky 
@id_objednavky INT, 
@id_zakaznika INT,
@id_zamestnance INT, 
@id_rozvazky INT, 
@datum_vytvoreni DateTime, 
@cena INT, 
@vyplacena CHAR(1)
AS
DECLARE @navyseni_kategorie CHAR(1) = 'N', @pocet_objednavek INT, @cena_nejlevnejsi_ob INT, @id_nejlevnejsi_ob INT, @test INT, @kategorie INT, @prumerna_hodnota INT;
BEGIN

BEGIN TRANSACTION
BEGIN TRY

SELECT @pocet_objednavek = COUNT(id_objednavky)
FROM Objednavka
WHERE Objednavka.id_zakaznika = @id_zakaznika;

WITH cte_objednavka AS (
    SELECT 
        ROW_NUMBER() OVER(
		     PARTITION BY id_zakaznika
             ORDER BY cena
        ) cislo_radku, 
        id_zakaznika, 
        id_objednavky, 
        cena
     FROM 
        Objednavka
) SELECT 
    @test = id_zakaznika, 
    @id_nejlevnejsi_ob = id_objednavky, 
    @cena_nejlevnejsi_ob = cena
FROM 
    cte_objednavka
WHERE id_zakaznika = 1
AND cislo_radku = 1
AND cena <= ALL
(
SELECT cena
FROM Objednavka
WHERE id_zakaznika = 1
AND vyplacena = 'N'
);


SELECT @kategorie = kategorie
FROM Zakaznik
WHERE Zakaznik.id_zakaznika = @id_zakaznika;

IF @pocet_objednavek = 20 OR @pocet_objednavek = 40 OR @pocet_objednavek = 60 OR @pocet_objednavek = 80
	UPDATE Objednavka
	SET vyplacena = 'Y'
	WHERE id_objednavky = @id_nejlevnejsi_ob;

IF @pocet_objednavek = 20 OR @pocet_objednavek = 40 OR @pocet_objednavek = 60 OR @pocet_objednavek = 80
	UPDATE Zakaznik
	SET kategorie = @kategorie + 1
	WHERE id_zakaznika = @id_zakaznika;

IF @pocet_objednavek = 20 OR @pocet_objednavek = 40 OR @pocet_objednavek = 60 OR @pocet_objednavek = 80
	SET	@navyseni_kategorie = 'Y'

SELECT @prumerna_hodnota = AVG(cena)
FROM Objednavka
WHERE Objednavka.id_zakaznika = @id_zakaznika;

IF @prumerna_hodnota IS NOT NULL AND @navyseni_kategorie = 'Y'
--IF @navyseni_kategorie = 'Y'
SET @cena = @cena - (@prumerna_hodnota * (0.1 + (@kategorie * 0.01))) - @cena_nejlevnejsi_ob;
IF @prumerna_hodnota IS NOT NULL AND @navyseni_kategorie = 'N'
SET @cena = @cena - (@prumerna_hodnota * (0.1 + (@kategorie * 0.01)));

IF @cena < 0 
SET @cena = 0;

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES (@id_objednavky, @id_zakaznika, @id_zamestnance, @id_rozvazky, @datum_vytvoreni, @cena, @vyplacena);

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
END