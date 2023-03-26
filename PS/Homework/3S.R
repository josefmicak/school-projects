library(readxl)
library(dplyr)
library(tidyr)
library(ggplot2)
library(ggpubr)
library(moments)
library(rstatix)
library(openxlsx)
library(lawstat)
library(BSDA)
library(FSA)
library(car)

setwd("...")

#a)

data5c = read_excel("data5c.xlsx")  # Uprav soubor, p��p. cestu k souboru

data5c$vyrobce = factor(data5c$vyrobce, 
                          levels = c("amber", "bright", "clear", "dim"),
                          labels = c("V�robce Amber", "V�robce Bright", "V�robce Clear", "V�robce Dim"))

#krabicovy graf, puvodni data
ggplot(data5c, # uprav
       aes(x = vyrobce,
           y = tok))+  # uprav
  stat_boxplot(geom = "errorbar",
               width = 0.15)+
  geom_boxplot()+
  labs(x = "", y = "Sv�teln� tok")+ # uprav
  theme_light()+
  theme(axis.ticks.x = element_blank(),
        axis.text = element_text(color = "black", size = 11))

outliers5c = 
  data5c %>% # uprav nazev dat
  identify_outliers(tok)  # uprav nazev promenne

data5c_nooutliers = read_excel("data5c_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

data5c_nooutliers$vyrobce = factor(data5c_nooutliers$vyrobce, 
                        levels = c("amber", "bright", "clear", "dim"),
                        labels = c("V�robce Amber", "V�robce Bright", "V�robce Clear", "V�robce Dim"))

#krabicovy graf, data po odstraneni odlehlych pozorovani
ggplot(data5c_nooutliers, # uprav
       aes(x = vyrobce,
           y = tok))+  # uprav
  stat_boxplot(geom = "errorbar",
               width = 0.15)+
  geom_boxplot()+
  labs(x = "", y = "Sv�teln� tok")+ # uprav
  theme_light()+
  theme(axis.ticks.x = element_blank(),
        axis.text = element_text(color = "black", size = 11))

#histogram, data po odstraneni odlehlych pozorovani
ggplot(data5c_nooutliers, # uprav
       aes(x = tok))+ # uprav
  geom_histogram(binwidth = 5, # uprav
                 color = "black",
                 fill = "grey55")+
  labs(x = "Sv�teln� tok", y = "�etnost")+ # uprav
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce",  # uprav
             dir = "v")

#qqgraf, data po odstraneni odlehlych pozorovani
ggplot(data5c_nooutliers, # uprav
       aes(sample = tok))+ # uprav
  stat_qq()+
  stat_qq_line()+
  labs(x = "Norm. teoretick� kvantily", y = "V�b�rov� kvantily")+
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce", # uprav
             ncol = 1, # uprav
             scales = "free")

#b)

data_nooutliers = read_excel("ukol_84_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

data_nooutliers = na.omit(data_nooutliers)

#Amber (5C)
moments::skewness(data_nooutliers$amber5)   # �ikmost 
moments::kurtosis(data_nooutliers$amber5)-3 # standardizovan� �pi�atost
shapiro.test(data_nooutliers$amber5)
symmetry.test(data_nooutliers$amber5, boot = FALSE) 

#Bright (5C)
moments::skewness(data_nooutliers$bright5)   # �ikmost 
moments::kurtosis(data_nooutliers$bright5)-3 # standardizovan� �pi�atost
shapiro.test(data_nooutliers$bright5)
symmetry.test(data_nooutliers$bright5, boot = FALSE) 

#Clear (5C)
moments::skewness(data_nooutliers$clear5)   # �ikmost 
moments::kurtosis(data_nooutliers$clear5)-3 # standardizovan� �pi�atost
shapiro.test(data_nooutliers$clear5)
symmetry.test(data_nooutliers$clear5, boot = FALSE) 

#Dim (5C)
moments::skewness(data_nooutliers$dim5)   # �ikmost 
moments::kurtosis(data_nooutliers$dim5)-3 # standardizovan� �pi�atost
shapiro.test(data_nooutliers$dim5)
symmetry.test(data_nooutliers$dim5, boot = FALSE) 

#c)
podklady = 
  data5c_nooutliers %>% 
  group_by(vyrobce) %>% 
  summarise(rozsah = length(na.omit(tok)),
            sikmost = moments::skewness(tok, na.rm = T),
            spicatost = moments::kurtosis(tok, na.rm = T)-3, 
            rozptyl = var(tok, na.rm = T),
            sm_odch = sd(tok, na.rm = T),
            prumer = mean(tok, na.rm = T),
            median = quantile(tok, 0.5, na.rm = T),
            Shapiruv_Wilkuv_phodnota = shapiro.test(tok)$p.value)

#u rozptylu vypsalo pouze cela cisla => vypisu 2 desetinna cisla
podklady = 
  data5c_nooutliers %>% 
  group_by(vyrobce) %>% 
  summarise(rozptyl = var(tok, na.rm = T),
            rozptyl2 = format(round(var(tok, na.rm = T), 2), nsmall = 2))

podklady

991.88/589.93 

bartlett.test(data5c_nooutliers$tok~data5c_nooutliers$vyrobce)
leveneTest(data5c_nooutliers$tok~data5c_nooutliers$vyrobce)

#d)

#Amber
median(data_nooutliers$amber5, na.rm=T)
format(round(median(data_nooutliers$amber5, na.rm=T), 2), nsmall = 2)
SIGN.test(data_nooutliers$amber5, md = median(data_nooutliers$amber5, na.rm=T), alternative = "two.sided", conf.level = 0.95)

#Bright
median(data_nooutliers$bright5, na.rm=T)
format(round(median(data_nooutliers$bright5, na.rm=T), 2), nsmall = 2)
SIGN.test(data_nooutliers$bright5, md = median(data_nooutliers$bright5, na.rm=T), alternative = "two.sided", conf.level = 0.95)

#Clear
median(data_nooutliers$clear5, na.rm=T)
format(round(median(data_nooutliers$clear5, na.rm=T), 2), nsmall = 2)
SIGN.test(data_nooutliers$clear5, md = median(data_nooutliers$clear5, na.rm=T), alternative = "two.sided", conf.level = 0.95)

#Dim
median(data_nooutliers$dim5, na.rm=T)
format(round(median(data_nooutliers$dim5, na.rm=T), 2), nsmall = 2)
SIGN.test(data_nooutliers$dim5, md = median(data_nooutliers$dim5, na.rm=T), alternative = "two.sided", conf.level = 0.95)

#e)

kruskal.test(data5c_nooutliers$tok~data5c_nooutliers$vyrobce)

dunnTest(tok ~ vyrobce, 
         data = data5c_nooutliers, 
         method = "bonferroni")