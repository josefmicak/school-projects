# -*- coding: utf-8 -*-

from tkinter import *
from math import sqrt


class MyApplication:
    GENERAL_TRIANGLE = "Obecný trojúhelník"
    RIGHT_TRIANGLE = "Pravoúhly trojúhelník"
    EQUILATERAL_TRIANGLE = "Rovnostraný trojúhelník"

    def __init__(self, root):
        self._root = root
        self._root.title("Triangle")
        

        self._top = Frame(self._root)
        self._top.pack()
        

        self._topH = Frame(self._top, relief = GROOVE, borderwidth = 2)
        self._topH.pack(fill = BOTH, padx = 4, pady = 4, side=TOP)
   
        self._top_label = Label(self._topH, text = "Obvod a obsah trojúhelníku")
        self._top_label.pack(fill = BOTH, padx = 8, pady = 8)
        

        self._left_frame = Frame(
            self._top, 
            relief = GROOVE, # FLAT, RAISED, SUNKEN, GROOVE, RIDGE
            borderwidth = 2, 
        )
        self._left_frame.pack(
            fill = Y, side=LEFT, 
            padx = 4, pady = 4, ipady = 4
        )
        

        self._label_a = Label(self._left_frame, text = "Strana a =")
        self._label_b = Label(self._left_frame, text = "Strana b =")
        self._label_c = Label(self._left_frame, text = "Strana c =")
        
  
        self._input_a = Entry(self._left_frame, width = 14)
        self._input_b = Entry(self._left_frame, width = 14)
        self._input_c = Entry(self._left_frame, width = 14)
        

        self._label_a.pack(fill=X, padx = 8, pady = 1)
        self._input_a.pack(padx = 8, pady = 1)
        self._label_b.pack(fill=X, padx = 8, pady = 1)
        self._input_b.pack(padx = 8, pady = 1)
        self._label_c.pack(fill=X, padx = 8, pady = 1)
        self._input_c.pack(padx = 8, pady = 1)
        

        self._button = Button(
            self._left_frame, 
            text = "Vymazat", 
            command = self.reset # command without brackets
            # command = lambda: self.reset() # alternative
        )
        self._button.pack(padx = 4, pady = 4)
        
        self.reset()
        

        self._rightFrame = Frame(self._top)
        self._rightFrame.pack(expand = TRUE, fill = BOTH, side = RIGHT, ipady = 4)
        self._rightFrameTopH = Frame(self._rightFrame, relief = GROOVE, borderwidth = 2)
        self._rightFrameTopH.pack(fill = BOTH, expand = TRUE, padx = 4, pady = 4, ipady = 4);
        self._rightFrameTopLabel = Label(self._rightFrameTopH, text = "Výsledek")
        self._rightFrameTopLabel.pack(fill = X)
        self._rightFrameCompute = Frame(self._rightFrameTopH, relief = SUNKEN, borderwidth = 2)
        self._rightFrameCompute.pack(fill = BOTH, expand = TRUE, padx = 8, pady = 4, ipady = 4)
        self._rightFrameComputeLabel = Label(self._rightFrameCompute, text = "Zatím žádný výsledek", background = "lightgrey")
        self._rightFrameComputeLabel.pack(fill = BOTH, expand = TRUE, ipadx = 8, ipady = 8)
        self._rightFrameD = Frame(self._rightFrame)
        self._rightFrameD.pack(fill = X)
        self._rightFrameDS = Frame(self._rightFrameD)
        self._rightFrameDS.pack(anchor = CENTER)

        self._computeButton = Button(
            self._rightFrameDS, 
            text = "Vyřešit", 
            command = self.solve
        )
        self._computeButton.pack(side = LEFT, padx = 8, pady = 8, ipadx = 8, ipady = 8)

        self._closeButton = Button(
            self._rightFrameDS, 
            text = "Konec", 
            command = exit
        )
        self._closeButton.pack(side = LEFT, padx = 8, pady = 8, ipadx = 8, ipady = 8)
        
    def reset(self):
        self._input_a.delete(0, END)
        self._input_a.insert(0, "0")
        self._input_a.focus_force()
        self._input_b.delete(0, END)
        self._input_b.insert(0, "0")
        self._input_c.delete(0, END)
        self._input_c.insert(0, "0")
        
    
    def solve(self):
        try:
            a = float(self._input_a.get())
            b = float(self._input_b.get())
            c = float(self._input_c.get())
            
            text = MyApplication.GENERAL_TRIANGLE
            if self.is_triangle(a, b, c):
                if self.is_right_triangle(a, b, c):
                    text = MyApplication.RIGHT_TRIANGLE
                if self.is_equilateral_triangle(a, b, c):
                    text = MyApplication.EQUILATERAL_TRIANGLE
                
                
                self._rightFrameComputeLabel.config(foreground="blue")
                obvod = "{:.2f}".format(self.compute_circumference(a, b, c))
                obsah = "{:.2f}".format(self.compute_area(a, b, c))
                output = text + "\n\nObvod: " + str(obvod) + "\nObsah: " + str(obsah)
            else:
                self._rightFrameComputeLabel.config(foreground="red")
                output = "Není trojúhelník"
                pass

        except ValueError:
            self._rightFrameComputeLabel.config(foreground="red")
            output = "Chyba\n\nNejméně jedna strana nebyla zadána"
            pass
        self._rightFrameComputeLabel.config(text = output)
        
    def compute_circumference(self, a, b, c):
        return a + b + c
    
    
    def compute_area(self, a, b, c):
        s = self.compute_circumference(a, b, c) / 2
        return sqrt(s * (s - a) * (s - b) * (s - c))
        
        
    def is_triangle(self, a, b, c):
        return a + b > c and a + c > b and b + c > a
        
        
    def is_right_triangle(self, a, b, c):
        return a*a + b*b == c*c or a*a + c*c == b*b or b*b + c*c == a*a
        
        
    def is_equilateral_triangle(self, a, b, c):
        return a == b and b == c
        

def main():
    root = Tk()
    root.minsize(300,230)
    app = MyApplication(root)
    root.mainloop()

main()
