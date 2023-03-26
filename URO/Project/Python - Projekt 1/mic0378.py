#Josef Micak MIC0378

from tkinter import *
import tkinter.tix 

class myApp:
  def __init__(self, master):
    
    self.menu = Menu(master)

    self.souborMenu = Menu(self.menu, tearoff=0)
    self.zobrazitMenu = Menu(self.menu, tearoff=0)
    self.nastaveniMenu = Menu(self.menu, tearoff=0)
    self.napovedaMenu = Menu(self.menu, tearoff=0)
    self.menu.add_cascade(label="Soubor", menu=self.souborMenu)
    self.menu.add_cascade(label="Zobrazit", menu=self.zobrazitMenu)
    self.menu.add_cascade(label="Nastavení", menu=self.nastaveniMenu)
    self.menu.add_cascade(label="Nápověda", menu=self.napovedaMenu)

    self.souborMenu.add_command(label="Nový")
    self.souborMenu.add_command(label="Otevřít")
    self.souborMenu.add_command(label="Uložit")
    self.souborMenu.add_separator()
    self.souborMenu.add_command(label="Náhled")
    self.souborMenu.add_command(label="Tisk")
    self.souborMenu.add_separator()
    self.souborMenu.add_command(label="Odeslat")
    self.souborMenu.add_separator()
    self.souborMenu.add_command(label="Zavřít", command=root.quit)

    self.zobrazitMenu.add_command(label="Přiblížit")
    self.zobrazitMenu.add_command(label="Najít")
    self.zobrazitMenu.add_separator()
    self.zobrazitMenu.add_command(label="Historie")
    self.zobrazitMenu.add_command(label="Statistiky")

    self.nastaveniMenu.add_command(label="Správa účtu")
    self.nastaveniMenu.add_command(label="Preference")
    self.nastaveniMenu.add_separator()
    self.nastaveniMenu.add_command(label="Možnosti")

    self.napovedaMenu.add_command(label="Zobrazit návod")
    self.napovedaMenu.add_separator()
    self.napovedaMenu.add_command(label="O aplikaci")

    master.config(menu=self.menu)

    #notebook
    self.nb = tkinter.tix.NoteBook(master)
    self.nb.add("page1", label="Správa zaměstnanců")
    self.nb.add("page2", label="Správa objednávek")
    self.nb.add("page3", label="Správa vozidel")

    self.p1 = self.nb.subwidget_list["page1"]
    self.p2 = self.nb.subwidget_list["page2"]
    self.p3 = self.nb.subwidget_list["page3"]

    self.nb.pack(expand=1, fill=BOTH)
    
    #page 1
    self.pridatZam = LabelFrame(self.p1, text="Přidat zaměstnance", padx=5, pady=5)
    self.pridatZam.grid(row=0, padx=3, pady=3, rowspan=15, sticky=N)

    self.jmenoZam = Label(self.pridatZam, text='Jméno')
    self.jmenoZam.grid(row=0, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.jmenoZamE = Entry(self.pridatZam)
    self.jmenoZamE.grid(row=0, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.prijmeniZam = Label(self.pridatZam, text='Přijmení')
    self.prijmeniZam.grid(row=1, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.prijmeniZamE = Entry(self.pridatZam)
    self.prijmeniZamE.grid(row=1, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.fo = StringVar()
    self.pohlaviZam = Label(self.pridatZam, text='Pohlaví')
    self.pohlaviZam.grid(row=2, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.r1 = Radiobutton(self.pridatZam, text="muž", variable=self.fo, value="muž")
    self.r1.grid(row=2, column=5, columnspan=5, padx=4, pady=4, sticky=W)
    self.r2 = Radiobutton(self.pridatZam, text="žena", variable=self.fo, value="žena")
    self.r2.grid(row=2, column=7, columnspan=5, padx=4, pady=4, sticky=W)
    self.r1.select()

    self.datumNarZam = Label(self.pridatZam, text='Datum narození')
    self.datumNarZam.grid(row=3, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.datumNarZamED = Entry(self.pridatZam, width=3)
    self.datumNarZamED.grid(row=3, column=5, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumNarZamEM = Entry(self.pridatZam, width=3)
    self.datumNarZamEM.grid(row=3, column=6, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumNarZamEY = Entry(self.pridatZam, width=7)
    self.datumNarZamEY.grid(row=3, column=7, columnspan=4, padx=4, pady=4, sticky=W)

    self.datumFormat = Label(self.pridatZam, text='(DD/MM/YYYY)')
    self.datumFormat.grid(row=4, column=0, columnspan=5, padx=4, pady=4, sticky=N)

    self.adresaZam = Label(self.pridatZam, text='Adresa')
    self.adresaZam.grid(row=5, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.adresaZamE = Entry(self.pridatZam, width=30)
    self.adresaZamE.grid(row=5, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.emailZam = Label(self.pridatZam, text='Email')
    self.emailZam.grid(row=6, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.emailZamE = Entry(self.pridatZam, width=30)
    self.emailZamE.grid(row=6, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.telefonZam = Label(self.pridatZam, text='Telefon')
    self.telefonZam.grid(row=7, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.telefonZamE = Entry(self.pridatZam, width=20)
    self.telefonZamE.grid(row=7, column=5, columnspan=5, padx=4, pady=4, sticky=W)
    
    self.datumNastZam = Label(self.pridatZam, text='Datum nástupu')
    self.datumNastZam.grid(row=8, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.datumNastZamED = Entry(self.pridatZam, width=3)
    self.datumNastZamED.grid(row=8, column=5, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumNastZamEM = Entry(self.pridatZam, width=3)
    self.datumNastZamEM.grid(row=8, column=6, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumNastZamEY = Entry(self.pridatZam, width=7)
    self.datumNastZamEY.grid(row=8, column=7, columnspan=4, padx=4, pady=4, sticky=W)

    self.datumFormat = Label(self.pridatZam, text='(DD/MM/YYYY)')
    self.datumFormat.grid(row=9, column=0, columnspan=5, padx=4, pady=4, sticky=N)
       
    self.ulozitZ = Button(self.pridatZam, text='Uložit')
    self.ulozitZ.grid(column=4, columnspan=3, row=10, padx=3, pady=3, ipadx = 10, sticky=W)
	
    self.zrusitZ = Button(self.pridatZam, text='Zrušit')
    self.zrusitZ.grid(column=5, columnspan=4, row=10, padx=3, pady=3, ipadx = 10)

    self.odebratZam = LabelFrame(self.p1, text="Odebrat zaměstnance", padx=5, pady=5)
    self.odebratZam.grid(row=0, column=1, padx=0, pady=0, sticky=N)

    self.IDZam = Label(self.odebratZam, text='ID zaměstnance')
    self.IDZam.grid(row=0, column=0, columnspan=2, padx=4, pady=4, sticky=W)
    self.IDZamE = Entry(self.odebratZam,width = 20)
    self.IDZamE.grid(row=0, column=2, columnspan=20, padx=4, pady=4, sticky=W)

    self.odebratZamB1 = Button(self.odebratZam, text='Uložit')
    self.odebratZamB1.grid(column=1, row=2, columnspan=4, padx=3, pady=3, ipadx=10)

    self.odebratZamB2 = Button(self.odebratZam, text='Zrušit')
    self.odebratZamB2.grid(column=4, row=2, columnspan=10, padx=3, pady=3, ipadx=10)

    self.vyhledatZam = Button(self.p1, text='Vyhledat zaměstnance')
    self.vyhledatZam.grid(column=1, row=1, padx=3, pady=3, ipadx=10, sticky=N)

    self.odebratZam = Button(self.p1, text='Odebrat všechny zaměstnance')
    self.odebratZam.grid(column=1, row=2, padx=3, pady=3, ipadx=10, sticky=N)

    self.potvrditZm1 = Button(self.p1, text='Potvrdit změny')
    self.potvrditZm1.grid(column=0, row=15, padx=3, pady=3, ipadx=10, sticky=E)

    self.zrusit1 = Button(self.p1, text='Zrušit')
    self.zrusit1.grid(column=1, row=15, padx=3, pady=3, ipadx=10, sticky=W)

    #page 2
    self.pridatObj = LabelFrame(self.p2, text="Přidat objednávku", padx=5, pady=5)
    self.pridatObj.grid(row=0, padx=3, pady=3, rowspan=15, sticky=N)

    self.jmenoZak = Label(self.pridatObj, text='Jméno zák.')
    self.jmenoZak.grid(row=0, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.jmenoZakE = Entry(self.pridatObj)
    self.jmenoZakE.grid(row=0, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.prijmeniZak = Label(self.pridatObj, text='Přijmení zák.')
    self.prijmeniZak.grid(row=1, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.prijmeniZakE = Entry(self.pridatObj)
    self.prijmeniZakE.grid(row=1, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.adresaZak = Label(self.pridatObj, text='Adresa zák.')
    self.adresaZak.grid(row=2, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.adresaZakE = Entry(self.pridatObj, width=30)
    self.adresaZakE.grid(row=2, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.telefonZak = Label(self.pridatObj, text='Telefon zák.')
    self.telefonZak.grid(row=3, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.telefonZakE = Entry(self.pridatObj, width=20)
    self.telefonZakE.grid(row=3, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.datumVytv = Label(self.pridatObj, text='Datum vytvoření')
    self.datumVytv.grid(row=4, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.datumVytvED = Entry(self.pridatObj, width=3)
    self.datumVytvED.grid(row=4, column=5, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumVytvEM = Entry(self.pridatObj, width=3)
    self.datumVytvEM.grid(row=4, column=6, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumVytvEY = Entry(self.pridatObj, width=7)
    self.datumVytvEY.grid(row=4, column=7, columnspan=4, padx=4, pady=4, sticky=W)

    self.datumFormat = Label(self.pridatObj, text='(DD/MM/YYYY)')
    self.datumFormat.grid(row=5, column=0, columnspan=5, padx=4, pady=4, sticky=N)

    self.cenaObj = Label(self.pridatObj, text='Cena')
    self.cenaObj.grid(row=6, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.cenaObjE = Entry(self.pridatObj)
    self.cenaObjE.grid(row=6, column=5, columnspan=5, padx=4, pady=4, sticky=W)
    self.cenaObjKc = Label(self.pridatObj, text='Kč')
    self.cenaObjKc.grid(row=6, column=8, columnspan=5, padx=4, pady=4, sticky=W)

    self.ulozitO = Button(self.pridatObj, text='Uložit')
    self.ulozitO.grid(column=4, columnspan=3, row=7, padx=3, pady=3, ipadx = 10, sticky=W)
	
    self.zrusitO = Button(self.pridatObj, text='Zrušit')
    self.zrusitO.grid(column=5, columnspan=4, row=7, padx=3, pady=3, ipadx = 10)

    self.odebratObj = LabelFrame(self.p2, text="Odebrat objednávku", padx=5, pady=5)
    self.odebratObj.grid(row=0, column=1, padx=0, pady=0, sticky=N)

    self.IDObj = Label(self.odebratObj, text='ID objednávky')
    self.IDObj.grid(row=0, column=0, columnspan=2, padx=4, pady=4, sticky=W)
    self.IDObjE = Entry(self.odebratObj,width = 20)
    self.IDObjE.grid(row=0, column=2, columnspan=20, padx=4, pady=4, sticky=W)

    self.odebratObjB1 = Button(self.odebratObj, text='Uložit')
    self.odebratObjB1.grid(column=1, row=2, columnspan=4, padx=3, pady=3, ipadx=10)

    self.odebratObjB2 = Button(self.odebratObj, text='Zrušit')
    self.odebratObjB2.grid(column=4, row=2, columnspan=10, padx=3, pady=3, ipadx=10)

    self.vyhledatObj = Button(self.p2, text='Vyhledat objednávku')
    self.vyhledatObj.grid(column=1, row=1, padx=3, pady=3, ipadx=10, sticky=N)

    self.odebratObj = Button(self.p2, text='Odebrat všechny objednávky')
    self.odebratObj.grid(column=1, row=2, padx=3, pady=3, ipadx=10, sticky=N)

    self.potvrditZm2 = Button(self.p2, text='Potvrdit změny')
    self.potvrditZm2.grid(column=0, row=15, padx=3, pady=3, ipadx=10, sticky=E)

    self.zrusit2 = Button(self.p2, text='Zrušit')
    self.zrusit2.grid(column=1, row=15, padx=3, pady=3, ipadx=10, sticky=W)
    
    #page 3
    self.pridatVoz = LabelFrame(self.p3, text="Přidat vozidlo", padx=5, pady=5)
    self.pridatVoz.grid(row=0, padx=3, pady=3, rowspan=15, sticky=N)

    self.modelVoz = Label(self.pridatVoz, text='Model')
    self.modelVoz.grid(row=0, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.modelVozE = Entry(self.pridatVoz, width=30)
    self.modelVozE.grid(row=0, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.SPZVoz = Label(self.pridatVoz, text='SPZ')
    self.SPZVoz.grid(row=1, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.SPZVozE = Entry(self.pridatVoz)
    self.SPZVozE.grid(row=1, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.datumPor = Label(self.pridatVoz, text='Datum pořízení')
    self.datumPor.grid(row=2, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.datumPorED = Entry(self.pridatVoz, width=3)
    self.datumPorED.grid(row=2, column=5, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumPorEM = Entry(self.pridatVoz, width=3)
    self.datumPorEM.grid(row=2, column=6, columnspan=4, padx=4, pady=4, sticky=W)
    self.datumPorEY = Entry(self.pridatVoz, width=7)
    self.datumPorEY.grid(row=2, column=7, columnspan=4, padx=4, pady=4, sticky=W)

    self.datumFormat = Label(self.pridatVoz, text='(DD/MM/YYYY)')
    self.datumFormat.grid(row=3, column=0, columnspan=5, padx=4, pady=4, sticky=N)

    self.objemKufru = Label(self.pridatVoz, text='Objem kufru')
    self.objemKufru.grid(row=4, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.objemKufruE = Entry(self.pridatVoz, width=20)
    self.objemKufruE.grid(row=4, column=5, columnspan=5, padx=4, pady=4, sticky=W)

    self.cenaVoz = Label(self.pridatVoz, text='Cena')
    self.cenaVoz.grid(row=5, column=0, columnspan=5, padx=4, pady=4, sticky=W)
    self.cenaVozE = Entry(self.pridatVoz, width=20)
    self.cenaVozE.grid(row=5, column=5, columnspan=5, padx=4, pady=4, sticky=W)
    self.cenaVozKc = Label(self.pridatVoz, text='Kč')
    self.cenaVozKc.grid(row=5, column=8, columnspan=5, padx=4, pady=4, sticky=W)

    self.ulozitV = Button(self.pridatVoz, text='Uložit')
    self.ulozitV.grid(column=4, columnspan=3, row=6, padx=3, pady=3, ipadx = 10, sticky=W)
	
    self.zrusitV = Button(self.pridatVoz, text='Zrušit')
    self.zrusitV.grid(column=5, columnspan=4, row=6, padx=3, pady=3, ipadx = 10)

    self.odebratVoz = LabelFrame(self.p3, text="Odebrat vozidlo", padx=5, pady=5)
    self.odebratVoz.grid(row=0, column=1, padx=0, pady=0, sticky=N)

    self.IDVoz = Label(self.odebratVoz, text='ID vozidla')
    self.IDVoz.grid(row=0, column=0, columnspan=2, padx=4, pady=4, sticky=W)
    self.IDVozE = Entry(self.odebratVoz, width = 20)
    self.IDVozE.grid(row=0, column=2, columnspan=20, padx=4, pady=4, sticky=W)

    self.odebratVozB1 = Button(self.odebratVoz, text='Uložit')
    self.odebratVozB1.grid(column=1, row=2, columnspan=7, padx=3, pady=3, ipadx=10)

    self.odebratVozB2 = Button(self.odebratVoz, text='Zrušit')
    self.odebratVozB2.grid(column=6, row=2, columnspan=11, padx=3, pady=3, ipadx=10, sticky=E)

    self.vyhledatVoz = Button(self.p3, text='Vyhledat vozidlo')
    self.vyhledatVoz.grid(column=1, row=1, padx=3, pady=3, ipadx=10, sticky=N)

    self.odebratVoz = Button(self.p3, text='Odebrat všechna vozidla')
    self.odebratVoz.grid(column=1, row=2, padx=3, pady=3, ipadx=10, sticky=N)

    self.potvrditZm3 = Button(self.p3, text='Potvrdit změny')
    self.potvrditZm3.grid(column=0, row=15, padx=3, pady=3, ipadx=10, sticky=E)

    self.zrusit3 = Button(self.p3, text='Zrušit')
    self.zrusit3.grid(column=1, row=15, padx=3, pady=3, ipadx=10, sticky=W)

root = tkinter.tix.Tk()
root.wm_title("Správa restaurace")
app = myApp(root)
root.mainloop()
#root.destroy()
