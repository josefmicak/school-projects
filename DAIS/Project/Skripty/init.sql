INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(1, 'Jan', 'Novak', '22 Bendova Ostrava-Radvanice', '420774158449', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(2, 'Petra', 'Novotna', '12 Hradecka Ostrava-Svinov', '420604584725', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(3, 'Pavel', 'Omacka', '125 Karvinska Orlova', '420776254441', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(4, 'Jiri', 'Blecha', '442 Nad Porubkou Ostrava-Poruba', '420723541165', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie, v_blacklistu)
VALUES(5, 'Patrik', 'Nimrod', '123 Orlovska Petrvald', '420741214628', 'N', 1, 'Y');

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(6, 'Kvetoslava', 'Homolkova', '54 Palickova Ostrava-Nova Ves', '420722145478', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(7, 'Zuzana', 'Svobodova', '777 Sionkova Ostrava-Slezska Ostrava', '420766452145', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(8, 'Antonin', 'Cerny', '12 Hradecka Ostrava-Svinov', '420604584725', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(9, 'Premysl', 'Vesely', '145 U statku Ostrava-Bartovice', '420733251425', 'N', 1);

INSERT INTO Zakaznik(id_zakaznika, jmeno, prijmeni, adresa, telefonni_cislo, neaktivni, kategorie)
VALUES(10, 'Dusan', 'Hala', '256 U sterkovny Hlucin', '420766452154', 'N', 1);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (1, 'Vaclav', 'Prochazka', '1256 Poklidna Ostrava-Vyskovice', '420625451468', 'M', '1985-04-08', '2014-10-10', 'Manazer', 25000);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (2, 'Karolina', 'Mastna', '1454 Kosmounautu Havirov', '420745145215', 'Z', '1996-10-22', '2014-10-15', 'Kuchar', 20000);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (3, 'Prokop', 'Buben', '412 Licha Ostrava-Michalkovice', '420785215361', 'M', '1984-01-01', '2015-08-08', 'Ridic', 18000);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (4, 'Ursula', 'Dobra', '666 Garazni Ostrava-Moravska Ostrava', '420722145156', 'Z', '2000-12-03', '2016-02-11', 'Kuchar', 20000);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (5, 'Radoslav', 'Kozeny', 'Demlova 323 Ostrava-Kuncice', '420654145125', 'M', '1995-02-03', '2017-05-14', 'Kuchar', 20000);

INSERT INTO Zamestnanec(id_zamestnance, jmeno, prijmeni, adresa, telefonni_cislo, pohlavi, datum_narozeni, datum_nastupu, pozice, plat)
VALUES (6, 'Klara', 'Horakova', 'Skrbenska 463 Senov', '420744152614', 'Z', '1978-07-09', '2018-09-07', 'Ridic', 18000);

INSERT INTO Stiznost(id_stiznosti, id_zakaznika, id_zamestnance, datum, typ_stiznosti, vyrizena)
VALUES(1, 9, 5, '2020-03-04 12:12:13', 3, 'Y');

INSERT INTO Stiznost(id_stiznosti, id_zakaznika, id_zamestnance, datum, typ_stiznosti, vyrizena)
VALUES(2, 4, 5, '2020-03-06 10:58:14', 1, 'N');

INSERT INTO Hodnoceni(id_hodnoceni, id_zakaznika, id_zamestnance, datum, hodnoceni)
VALUES(1, 3, 4, '2020-03-02 13:23:44', 5);

INSERT INTO Hodnoceni(id_hodnoceni, id_zakaznika, id_zamestnance, datum, hodnoceni)
VALUES(2, 9, 2, '2020-03-02 16:45:28', 10);

INSERT INTO Hodnoceni(id_hodnoceni, id_zakaznika, id_zamestnance, datum, hodnoceni)
VALUES(3, 10, 2, '2020-03-05 21:02:45', 9);

INSERT INTO Hodnoceni(id_hodnoceni, id_zakaznika, id_zamestnance, datum, hodnoceni)
VALUES(4, 9, 3, '2020-03-08 14:44:47', 8);

INSERT INTO Vozidlo(id_vozidla, datum_porizeni, cena, objem_kufru, znacka, pocet_ujetych_km)
VALUES(1, '2017-11-23', 150000, 300, '6T58086', 23998);

INSERT INTO Vozidlo(id_vozidla, datum_porizeni, cena, objem_kufru, znacka, pocet_ujetych_km)
VALUES(2, '2018-10-10', 115000, 450, '2T81241', 50246);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(1, 1, '2017-11-23', 3214);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(2, 1, '2017-12-01', 3227);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(3, 1, '2018-03-01', 6415);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(4, 1, '2018-06-01', 9124);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(5, 1, '2018-09-01', 12416);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(6, 2, '2018-10-10', 41245);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(7, 1, '2018-12-01', 15987);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(8, 2, '2018-12-01', 42236);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(9, 1, '2019-03-01', 18045);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(10, 2, '2019-03-01', 44982);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(11, 1, '2019-06-01', 21325);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(12, 2, '2019-06-01', 48412);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(13, 1, '2019-09-01', 23350);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(14, 2, '2019-09-01', 50045);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(15, 1, '2019-09-12', 24653);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(16, 2, '2019-09-12', 52142);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(17, 1, '2020-04-03', 27414);

INSERT INTO Historie_ujetych_km(id_zaznamu, id_vozidla, datum_zaznamu, pocet_ujetych_km)
VALUES(18, 2, '2020-04-03', 55645);

INSERT INTO Rozvazka(id_rozvazky, id_zamestnance, id_vozidla, cas_odjezdu, cas_prijezdu)
VALUES(1, 3, 1, '2020-03-05 13:30:32', '2020-03-05 14:38:14');

INSERT INTO Rozvazka(id_rozvazky, id_zamestnance, id_vozidla, cas_odjezdu, cas_prijezdu)
VALUES(2, 6, 2, '2020-03-05 20:03:10', '2020-03-05 21:15:10');

INSERT INTO Rozvazka(id_rozvazky, id_zamestnance, id_vozidla, cas_odjezdu, cas_prijezdu)
VALUES(3, 3, 1, '2020-03-07 15:22:20', '2020-03-07 16:13:05');

INSERT INTO Rozvazka(id_rozvazky, id_zamestnance, id_vozidla, cas_odjezdu, cas_prijezdu)
VALUES(4, 6, 2, '2020-03-07 20:24:55', '2020-03-07 21:16:33');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(1, 2, 5, 1, '2020-03-05 12:30:18', 159, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(2, 10, 5, 1, '2020-03-05 12:48:16', 249, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(3, 7, 5, 1, '2020-03-05 12:54:46', 115, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(4, 4, 4, 1, '2020-03-05 13:03:55', 179, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(5, 5, 4, 1, '2020-03-05 13:10:01', 219, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(6, 9, 2, 2, '2020-03-05 19:01:14', 301, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(7, 8, 2, 2, '2020-03-05 19:08:33', 436, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(8, 6, 4, 2, '2020-03-05 19:19:57', 139, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(9, 3, 4, 2, '2020-03-05 19:30:00', 199, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(10, 2, 2, 2, '2020-03-05 19:45:21', 254, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(11, 4, 2, 3, '2020-03-07 14:10:21', 345, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(12, 8, 2, 3, '2020-03-07 14:33:17', 159, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(13, 7, 2, 3, '2020-03-07 14:41:28', 246, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(14, 1, 2, 3, '2020-03-07 14:49:01', 289, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(15, 3, 5, 4, '2020-03-07 20:15:44', 174, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(16, 7, 4, 4, '2020-03-07 20:17:56', 516, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(17, 10, 4, 4, '2020-03-07 20:28:04', 321, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(18, 1, 5, 4, '2020-03-07 20:35:34', 149, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(19, 4, 4, 4, '2020-03-07 20:48:17', 229, 'N');

INSERT INTO Objednavka(id_objednavky, id_zakaznika, id_zamestnance, id_rozvazky, datum_vytvoreni, cena, vyplacena)
VALUES(20, 2, 5, 4, '2020-03-07 20:59:01', 206, 'N');