library(readxl)
library(dplyr)
library(ggplot2)
library(moments)
library(rstatix)
library(openxlsx)
library(lawstat)
library(BSDA)
library(ggmosaic) 
library(lsr)
library(epiR)
library(FSA)
library(car)
library(tidyr)

#2
1-0.48-0.3-0.04-0.12
0.3+0.48+0.06

#3
dpois(0,40)
dpois(10,40)
dpois(20,40)
dpois(30,40)
dpois(40,40)
dpois(50,40)
dpois(60,40)

#4
data = read_excel("data_ver220516A.xlsx")  # Uprav soubor, pøíp. cestu k souboru

data =
  data %>% 
  mutate(pokles = m0-m1)

outliers = 
  data %>% # uprav nazev dat
  group_by(skupina) %>% # uprav nazev promenne
  identify_outliers(pokles)  # uprav nazev promenne

keto = read_excel("keto.xlsx")  # Uprav soubor, pøíp. cestu k souboru
ketohiit = read_excel("ketohiit.xlsx")  # Uprav soubor, pøíp. cestu k souboru

outliers = 
  ketohiit %>% # uprav nazev dat
  identify_outliers(pokles)  # uprav nazev promenne

shapiro.test(keto$pokles)

shapiro.test(ketohiit$pokles)

mean(keto$pokles)
t.test(keto$pokles, alternative="greater",conf.level=0.95)
mean(ketohiit$pokles)
t.test(ketohiit$pokles, alternative="greater",conf.level=0.95)

#c)
datamerged = rbind(keto,ketohiit)

var.test(datamerged$pokles~datamerged$skupina)

t.test(datamerged$pokles[datamerged$skupina=="KETO"], 
       datamerged$pokles[datamerged$skupina=="KETO+HIIT"], 
       alternative = "greater", 
       var.equal = TRUE,     # shoda rozptylù KO
       conf.level = 0.95)

#5
kontrol = read_excel("kontrol.xlsx")  # Uprav soubor, pøíp. cestu k souboru
hiit = read_excel("hiit.xlsx")  # Uprav soubor, pøíp. cestu k souboru

shapiro.test(kontrol$pokles)
shapiro.test(hiit$pokles)

kruskal.test(datamerged$pokles~datamerged$skupina)