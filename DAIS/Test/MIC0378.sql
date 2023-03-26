create or replace procedure PrintPurchases(znacka varchar2)
as
pocetProduktu int;
pocetObjednavek int;
pohlavi varchar(20);
obsahuje int := 0;
begin

for y in (select trademark from product) loop
if y.trademark = znacka then
obsahuje := 1;
end if;
end loop;

if obsahuje = 0 then
dbms_output.put_line(znacka || ' neobsahuje zadne produkty');
return;
end if;

if obsahuje = 1 then
select count(pid) into pocetProduktu from product where trademark = znacka;
dbms_output.put_line(znacka || '#' || pocetProduktu);
for x in (select cid, name from customer) loop

select count(nid) into pocetObjednavek
from purchase
join customer on customer.cid = purchase.cid
join product on product.pid = purchase.pid
where customer.cid = x.cid
and product.trademark = znacka;

if pocetObjednavek > 0 then
dbms_output.put_line(x.cid || ' ' || x.name || ' ' || pocetObjednavek);
end if;

if pocetObjednavek = 0 then
select gender into pohlavi
from customer
where customer.cid = x.cid;
if pohlavi = 'muz' then
dbms_output.put_line(x.cid || ' ' || x.name ||  ' ' || 'nezakoupil');
end if;

if pohlavi = 'zena' then
dbms_output.put_line(x.cid || ' ' || x.name || ' ' ||  'nezakoupila');
end if;
end if;
end loop;
end if;

exception
when others then
dbms_output.put_line('Nastala neocekavana chyba');
return;

end;

=====================================================================================================

alter table product add isFeatured int default 0;

alter table product add check (isFeatured in(0,1));

create table CompletedProcedures(procedure_name varchar(100), start_date date)

create or replace procedure SetFeaturedProducts
as
maxpocet int;
begin

select(pocet) into maxpocet
    from
    (
        select count(purchase.pid) pocet
        from purchase
        group by purchase.pid
    );
    
if maxpocet > 0 then
for x in 
(
select product.pid, count(product.pid)
from product
join purchase on purchase.pid = product.pid
group by product.pid
having count(product.pid) = maxpocet
) loop

update product
set isfeatured = 1
where product.pid = x.pid;

end loop;

for y in 
(
select product.pid, count(product.pid)
from product
join purchase on purchase.pid = product.pid
group by product.pid
having count(product.pid) < maxpocet
) loop

update product
set isfeatured = 0
where product.pid = y.pid;

end loop;
insert into completedprocedures(procedure_name, start_date) values ($$PLSQL_UNIT, current_date);
end if;

exception
        when others then
        dbms_output.put_line('Nastala neocekavana chyba');

end;