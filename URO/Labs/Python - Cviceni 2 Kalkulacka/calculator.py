# ------------------------------------------------------------------------------#
# Kalkulacka                                                                   #
# ------------------------------------------------------------------------------#

from tkinter import *
from math import *
from tkinter import font
from tkinter import messagebox

class MyApp:

    def big(self):
        self.font.config(weight="bold", size=14)
    def normal(self):
        self.font.config(weight="normal", size=12)

    def insKey(self, znak):
        self.s=self.la['text']
        if znak == "=":
            self.r = str(eval(self.s));
            self.s = self.r;
        elif znak == "←":
            self.s = self.s[:-1]
        elif znak == "ce" or znak == "c":
            self.s = "0"
        elif znak == "+/-":
            self.s = float(self.s)
            self.s = str(-self.s)
        elif znak == ".":
            x = 0
            y = 0
            last = self.s[len(self.s)-1]
            for s in self.s:
                if s == ".":
                    x = x+1
                if s == "+" or s == "-" or s == "*" or s == "/":
                    y = y+1
            if x <= y and (last == "0" or last == "1" or last == "2" or last == "3" or last == "4" or last == "5" or last == "6" or last == "7" or last == "8" or last == "9"):
                self.s = self.s + znak
        elif self.s == "0":
            self.s = znak
        else:
            self.s = self.s + znak

        self.la.config(text=self.s)

    def __init__(self, root):
        self.fo = StringVar()
        self.color = StringVar()
        self.color = "#FFFFFF"

        self.s = StringVar()
        self.r = StringVar()

        root.title("Calculator")
        self.font = font.Font(size=10, weight="normal")

        self.la = Label(root, text="0", background="#FFFFFF", anchor=E, relief=SUNKEN, height=2, font=self.font)
        self.la.pack(fill=X, side=TOP, padx=8, pady=5)

        self.opts = Frame(root, relief=GROOVE)
        self.opts.pack()

        self.nor = Radiobutton(self.opts, text="Normal", variable=self.fo, value="normal", command=self.normal,
                               font=self.font)
        self.big = Radiobutton(self.opts, text="Big", variable=self.fo, value="big", command=self.big,
                               font=self.font)
        self.nor.pack(side=LEFT)
        self.big.pack(side=RIGHT)

        self.numbts = Frame(root)
        self.numbts.pack(fill=Y, expand=1, padx=4, pady=4)

        self.nula = Button(self.numbts, text="0", width=5, height=2, font=self.font, command=lambda: self.insKey("0"))
        self.carka = Button(self.numbts, text=".", width=5, height=2, font=self.font, command=lambda: self.insKey("."))
        self.plus = Button(self.numbts, text="+", width=5, height=2, font=self.font, command=lambda: self.insKey("+"))
        self.rovnase = Button(self.numbts, text="=", width=5, height=2, font=self.font, command=lambda: self.insKey("="))
        self.jedna = Button(self.numbts, text="1", width=5, height=2, font=self.font, command=lambda: self.insKey("1"))
        self.dve = Button(self.numbts, text="2", width=5, height=2, font=self.font, command=lambda: self.insKey("2"))
        self.tri = Button(self.numbts, text="3", width=5, height=2, font=self.font, command=lambda: self.insKey("3"))
        self.minus = Button(self.numbts, text="-", width=5, height=2, font=self.font, command=lambda: self.insKey("-"))
        self.ctyri = Button(self.numbts, text="4", width=5, height=2, font=self.font, command=lambda: self.insKey("4"))
        self.pet = Button(self.numbts, text="5", width=5, height=2, font=self.font, command=lambda: self.insKey("5"))
        self.sest = Button(self.numbts, text="6", width=5, height=2, font=self.font, command=lambda: self.insKey("6"))
        self.krat = Button(self.numbts, text="*", width=5, height=2, font=self.font, command=lambda: self.insKey("*"))
        self.sedm = Button(self.numbts, text="7", width=5, height=2, font=self.font, command=lambda: self.insKey("7"))
        self.osm = Button(self.numbts, text="8", width=5, height=2, font=self.font, command=lambda: self.insKey("8"))
        self.devet = Button(self.numbts, text="9", width=5, height=2, font=self.font, command=lambda: self.insKey("9"))
        self.lomeno = Button(self.numbts, text="/", width=5, height=2, font=self.font, command=lambda: self.insKey("/"))
        self.procento = Button(self.numbts, text="%", width=5, height=2, font=self.font, command=lambda: self.insKey("%"))
        self.arrowleft = Button(self.numbts, text="←", width=5, height=2, font=self.font, command=lambda: self.insKey("←"))
        self.ce = Button(self.numbts, text="CE", width=5, height=2, font=self.font, command=lambda: self.insKey("ce"))
        self.c = Button(self.numbts, text="C", width=5, height=2, font=self.font, command=lambda: self.insKey("c"))
        self.plusminus = Button(self.numbts, text="+/-", width=5, height=2, font=self.font, command=lambda: self.insKey("+/-"))

        self.nula.grid(row=5, column=0, columnspan=2, sticky=W + E + N + S, padx=2, pady=2)
        self.carka.grid(row=5, column=2, sticky=W + E + N + S, padx=2, pady=2)
        self.plus.grid(row=5, column=3, sticky=W + E + N + S, padx=2, pady=2)
        self.rovnase.grid(row=4, column=4, rowspan=2, sticky=W + E + N + S, padx=2, pady=2)
        self.jedna.grid(row=4, column=0, sticky=W + E + N + S, padx=2, pady=2)
        self.dve.grid(row=4, column=1, sticky=W + E + N + S, padx=2, pady=2)
        self.tri.grid(row=4, column=2, sticky=W + E + N + S, padx=2, pady=2)
        self.minus.grid(row=4, column=3,sticky=W + E + N + S, padx=2, pady=2)
        self.ctyri.grid(row=3, column=0, sticky=W + E + N + S, padx=2, pady=2)
        self.pet.grid(row=3, column=1, sticky=W + E + N + S, padx=2, pady=2)
        self.sest.grid(row=3, column=2, sticky=W + E + N + S, padx=2, pady=2)
        self.krat.grid(row=3, column=3, sticky=W + E + N + S, padx=2, pady=2)
        self.sedm.grid(row=2, column=0, sticky=W + E + N + S, padx=2, pady=2)
        self.osm.grid(row=2, column=1, sticky=W + E + N + S, padx=2, pady=2)
        self.devet.grid(row=2, column=2,sticky=W + E + N + S, padx=2, pady=2)
        self.lomeno.grid(row=2, column=3, sticky=W + E + N + S, padx=2, pady=2)
        self.procento.grid(row=2, column=4, rowspan=2, sticky=W + E + N + S, padx=2, pady=2)
        self.arrowleft.grid(row=1, column=0, sticky=W + E + N + S, padx=2, pady=2)
        self.ce.grid(row=1, column=1, sticky=W + E + N + S, padx=2, pady=2)
        self.c.grid(row=1, column=2, sticky=W + E + N + S, padx=2, pady=2)
        self.plusminus.grid(row=1, column=3, columnspan=2, sticky=W + E + N + S, padx=2, pady=2)


        # self.btn.config(state=DISABLED)
        self.nor.select()

root = Tk()
root.minsize(260,320)
app = MyApp(root)
root.mainloop()
