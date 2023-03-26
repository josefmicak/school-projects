# -*- coding: utf-8 -*-

from tkinter import *
from tkinter import ttk
import MultiListbox as table

data = [
       ["Petr", "Bílý","045214/1512", "17. Listopadu", 15, "Ostrava", 70800,"poznamka"],
       ["Jana", "Zelený","901121/7238", "Vozovna", 54, "Poruba", 78511,""],
       ["Karel", "Modrý","800524/5417", "Porubská", 7, "Praha", 11150,""],
       ["Martin", "Stříbrný","790407/3652", "Sokolovská", 247, "Brno", 54788,"nic"]]

class App:


    def __init__(self, root):
        self.row = IntVar()
        self.jmeno = StringVar()
        self.prijmeni = StringVar()
        self.rc = StringVar()
        self.ulice = StringVar()
        self.cp = StringVar()
        self.mesto = StringVar()
        self.psc = StringVar()

        self.img = Frame(root)
        self.img.pack()
        
        self.b=Button(self.img, command = self.add)
        self.photo=PhotoImage(file="newfile.png")
        self.b.config(image=self.photo,width="95",height="95")
        self.b.pack(side=LEFT)

        self.b2=Button(self.img, command = self.update)
        self.photo2=PhotoImage(file="savefile.png")
        self.b2.config(image=self.photo2,width="95",height="95")
        self.b2.pack(side=LEFT)

        self.mlb = table.MultiListbox(root, (('Jméno', 20), ('Příjmení', 20), ('Rodné číslo', 12)))
        for i in range(len(data)):
            self.mlb.insert(END, (data[i][0], data[i][1],data[i][2]))
        self.mlb.pack(expand=YES,fill=BOTH, padx=10, pady=10)
        self.mlb.subscribe( lambda row: self.edit( row ) )
        
        self.gr = Frame(root)
        self.gr.pack()

        self.l1 = Label(self.gr, text="Jmeno:")
        self.l2 = Label(self.gr, text="Prijmeni:")
        self.l3 = Label(self.gr, text="Rodne Cislo:")
        self.e1 = Entry(self.gr, textvariable=self.jmeno)
        self.e2 = Entry(self.gr, textvariable=self.prijmeni)
        self.e3 = Entry(self.gr, textvariable=self.rc, width=12)

        self.l1.grid(row=0, column=0, sticky=E, padx=4, pady=4)
        self.l2.grid(row=1, column=0, sticky=E, padx=4, pady=4)
        self.l3.grid(row=2, column=0, sticky=E, padx=4, pady=4)
        self.e1.grid(row=0, column=1, sticky=W, padx=4, pady=4)
        self.e2.grid(row=1, column=1, sticky=W, padx=4, pady=4)
        self.e3.grid(row=2, column=1, sticky=W, padx=4, pady=4)

        self.nb = ttk.Notebook(root)
        self.p1 = Frame(self.nb)
        self.p2 = Frame(self.nb)
        self.nb.add(self.p1, text="Adresa")
        self.nb.add(self.p2, text="Poznamka")
        self.nb.pack(expand=1, fill=BOTH)
        # p1
        self.gr1 = Frame(self.p1)
        self.gr1.pack(padx=100)
        self.u = Label(self.gr1, text="Ulice:")
        self.m = Label(self.gr1, text="Mesto:")
        self.p = Label(self.gr1, text="PSC:")
        self.c = Label(self.gr1, text="c.p.:")
        self.en1 = Entry(self.gr1, textvariable=self.ulice)
        self.en2 = Entry(self.gr1, textvariable=self.mesto)
        self.en3 = Entry(self.gr1, textvariable=self.psc, width=12)
        self.en4 = Entry(self.gr1, textvariable=self.cp, width=8)

        self.u.grid(row=0, column=0, sticky=E, padx=4, pady=4)
        self.m.grid(row=1, column=0, sticky=E, padx=4, pady=4)
        self.p.grid(row=2, column=0, sticky=E, padx=4, pady=4)
        self.c.grid(row=0, column=2, sticky=E, padx=4, pady=4)
        self.en1.grid(row=0, column=1, sticky=W, padx=4, pady=4)
        self.en2.grid(row=1, column=1, sticky=W, padx=4, pady=4)
        self.en3.grid(row=2, column=1, sticky=W, padx=4, pady=4)
        self.en4.grid(row=0, column=3, sticky=W, padx=4, pady=4)

        self.nb.pack(fill=BOTH, padx=5, pady=5)

        self.text=Text(self.p2, height=5, width=20)
        self.text.pack(expand=1,fill=BOTH)

        self.gr2 = Frame(root)
        self.gr2.pack(padx=100)
        self.b1 = Button(self.gr2, text="Nový záznam", width=15, command=self.add)
        self.b2 = Button(self.gr2, text="Uložit záznam", width=15, command=self.update)
        self.b3 = Button(self.gr2, text="Konec", width=15, command=root.quit)
        self.b1.grid(row=0, column=0, padx=4, pady=4)
        self.b2.grid(row=0, column=1, padx=4, pady=4)
        self.b3.grid(row=0, column=2, padx=4, pady=4)

        self.menubar = Menu(root)
        self.filemenu = Menu(self.menubar, tearoff=0)
        self.menubar.add_cascade(label="Soubor", menu=self.filemenu)
        self.filemenu.add_command(label="O programu")
        self.filemenu.add_separator()
        self.filemenu.add_command(label="Konec", command=root.quit)
        self.filemenu2 = Menu(self.menubar, tearoff=0)
        self.menubar.add_cascade(label="Nastavení", menu=self.filemenu2)
        self.filemenu3 = Menu(self.menubar, tearoff=0)
        self.menubar.add_cascade(label="Nápověda", menu=self.filemenu3)

        root.config(menu=self.menubar)      

    def edit(self, row):
        self.row=row
        self.jmeno.set(data[row][0])
        self.prijmeni.set(data[row][1])
        self.rc.set(data[row][2])
        self.ulice.set(data[row][3])
        self.mesto.set(data[row][5])
        self.psc.set(data[row][6])
        self.cp.set(data[row][4])
        self.text.delete(1.0, END)
        self.text.insert(END, data[row][7])



    def update(self):
        for i in range(len(data)):
            if data[i][2] == self.e3.get():
                data[i][0] = self.e1.get()
                data[i][1] = self.e2.get()
                data[i][2] = self.e3.get()
                data[i][3] = self.en1.get()
                data[i][4] = self.en2.get()
                data[i][5] = self.en3.get()
                data[i][6] = self.en4.get()
        self.mlb.delete(0,END)
        for i in range(len(data)):
            self.mlb.insert(END, (data[i][0], data[i][1],data[i][2]))

        

    def add(self):
        data.append([self.e1.get(), self.e2.get(), self.e3.get(), self.en1.get(), self.en2.get(), self.en3.get(), self.en4.get(), self.text.get(1.0, END)])
        self.mlb.insert(END, (data[len(data)-1][0], data[len(data)-1][1], data[len(data)-1][2]))



root = Tk()
root.minsize(600,600)
root.wm_title("Formulář")
app = App(root)
root.mainloop()

