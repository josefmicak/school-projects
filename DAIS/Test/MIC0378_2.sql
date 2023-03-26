--1. uloha

create table Statistics
(
id int primary key,
timespan varchar(30),
progress varchar(20)
);

create table vysledky
(
mesicid int,
suma int
);

create or replace procedure ComputeProgress(customer_id customer.cid%TYPE)
as
poradi int := 0;
datum varchar(30);
celkovacena int;
pocetvysledku int;
procenta int;
poslednimesic int;
procentavysledek varchar(20);
znak varchar(1) := ' ';
begin
for x in
(
select distinct extract(month from purchaseday) as mesic, extract(year from purchaseday) as rok, sum(price) as hodnota
from purchase
join customer on customer.cid = purchase.cid
where customer.cid = customer_id
group by extract(year from purchaseday), extract(month from purchaseday)
order by extract(year from purchaseday), extract(month from purchaseday)
) loop
poradi := poradi + 1;
datum := x.mesic || '/' || x.rok;

insert into vysledky values(poradi, x.hodnota);

select count(*) into pocetvysledku
from vysledky;

if pocetvysledku = 0 then
procenta := 0;
else

select suma into poslednimesic
from vysledky
where rownum = 1
order by mesicid desc;

procenta := 100 - ((poslednimesic / x.hodnota) * 100);
end if;

if poslednimesic < x.hodnota then
znak := '+';
end if;

if poslednimesic > x.hodnota then
znak := '-';
end if;

if poradi = 1 then
procentavysledek := '0';
else
procentavysledek := znak || ' ' || procenta || ' %';
end if;

insert into statistics values(poradi, datum, procentavysledek);

end loop;
end ComputeProgress;

-----------------------------------------------------------------------------------------------
--2. uloha

create or replace function InsertComplaint (v_nID purchase.nid%TYPE)
return varchar is
ret varchar(50);
pocetnakupu int;
neexistuje exception;
pocetreklamaci int;
idzamestnance int;
cenanakupu int;
begin
select count(purchase.nid) into pocetnakupu
from purchase
where purchase.nid = v_nID;

if pocetnakupu = 0 then
raise neexistuje;
end if;

select count(*) into pocetreklamaci
from complaint
where complaint.nid = v_nid;

if pocetreklamaci = 0 then
select eid into idzamestnance
from purchase
where purchase.nid = v_nID;
ret := 'Prvni reklamace uznana - produkt v oprave';
insert into complaint values(v_nid, idzamestnance, 1, null, null);

elsif pocetreklamaci = 1 then

select eid into idzamestnance
from complaint
where complaint.nid = v_nID;
ret := 'Druha reklamace uznana - produkt v oprave';
insert into complaint values(v_nid, idzamestnance, 2, null, null);

elsif pocetreklamaci = 2 then

select eid into idzamestnance
from complaint
where complaint.nid = v_nID
and complaintorder = 2;

select price into cenanakupu
from purchase
where purchase.nid = v_nID;
ret := 'Treti reklamace uznana - vraceny penize';
insert into complaint values(v_nid, idzamestnance, 3, 0, cenanakupu);
end if;

return ret;

exception
when neexistuje then
return 'Nakup neexistuje';

end InsertComplaint;

declare text varchar(50);
begin
text := InsertComplaint(100);
dbms_output.put_line(text);
end;