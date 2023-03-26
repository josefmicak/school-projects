library(readxl)
library(dplyr)
library(tidyr)
library(ggplot2)
library(ggpubr)
library(moments)
library(rstatix)

setwd("...")

datadu = read_excel("ukol_84.xlsx")  # Uprav soubor, p��p. cestu k souboru

data = read.csv2(file = "aku_st.csv")
colnames(data) = c("ID","kapacitapo5","kapacitapo100","vyrobce") 

poklesa = read_excel("poklesa.xlsx")  # Uprav soubor, p��p. cestu k souboru

moje_tab = 
  poklesa %>%
  summarise(rozsah = length(na.omit(pokles)),
            minimum = min(pokles, na.rm=T),
            Q1 = quantile(pokles, 0.25, na.rm=T), #dolni kvartil
            prumer = mean(pokles, na.rm=T),
            median = median(pokles, na.rm=T),
            Q3 = quantile(pokles, 0.75, na.rm=T), #horni kvartil
            maximum = max(pokles, na.rm=T),
            rozptyl = var(pokles, na.rm=T),
            smerodatna_odchylka = sd(pokles,na.rm=T),
            variacni_koeficient = (100*(smerodatna_odchylka/(abs(prumer)))), 
            sikmost = (moments::skewness(pokles, na.rm=T)),
            stand_spicatost = (moments::kurtosis(pokles, na.rm=T)-3),
            dolni_mez_hradeb = Q1-1.5*(Q3-Q1),
            horni_mez_hradeb = Q3+1.5*(Q3-Q1))

t(moje_tab)

poklesb = read_excel("poklesb.xlsx")  # Uprav soubor, p��p. cestu k souboru

moje_tab = 
  poklesb %>%
  summarise(rozsah = length(na.omit(pokles)),
            minimum = min(pokles, na.rm=T),
            Q1 = quantile(pokles, 0.25, na.rm=T), #dolni kvartil
            prumer = mean(pokles, na.rm=T),
            median = median(pokles, na.rm=T),
            Q3 = quantile(pokles, 0.75, na.rm=T), #horni kvartil
            maximum = max(pokles, na.rm=T),
            rozptyl = var(pokles, na.rm=T),
            smerodatna_odchylka = sd(pokles,na.rm=T),
            variacni_koeficient = (100*(smerodatna_odchylka/(abs(prumer)))), 
            sikmost = (moments::skewness(pokles, na.rm=T)),
            stand_spicatost = (moments::kurtosis(pokles, na.rm=T)-3),
            dolni_mez_hradeb = Q1-1.5*(Q3-Q1),
            horni_mez_hradeb = Q3+1.5*(Q3-Q1))

t(moje_tab)

outliersa = 
  poklesa %>% # uprav nazev dat
  identify_outliers(pokles)  # uprav nazev promenne

poklesa_nooutliers = read_excel("poklesa_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

moje_tab = 
  poklesa_nooutliers %>%
  summarise(rozsah = length(na.omit(pokles)),
            minimum = min(pokles, na.rm=T),
            Q1 = quantile(pokles, 0.25, na.rm=T), #dolni kvartil
            prumer = mean(pokles, na.rm=T),
            median = median(pokles, na.rm=T),
            Q3 = quantile(pokles, 0.75, na.rm=T), #horni kvartil
            maximum = max(pokles, na.rm=T),
            rozptyl = var(pokles, na.rm=T),
            smerodatna_odchylka = sd(pokles,na.rm=T),
            variacni_koeficient = (100*(smerodatna_odchylka/prumer)), 
            sikmost = (moments::skewness(pokles, na.rm=T)),
            stand_spicatost = (moments::kurtosis(pokles, na.rm=T)-3),
            dolni_mez_hradeb = Q1-1.5*(Q3-Q1),
            horni_mez_hradeb = Q3+1.5*(Q3-Q1))

t(moje_tab)

1.8515625 - 2*(5.0512608)
1.8515625 + 2*(5.0512608)

outliersb = 
  poklesb %>% # uprav nazev dat
  identify_outliers(pokles)  # uprav nazev promenne

poklesb_nooutliers = read_excel("poklesb_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

moje_tab = 
  poklesb_nooutliers %>%
  summarise(rozsah = length(na.omit(pokles)),
            minimum = min(pokles, na.rm=T),
            Q1 = quantile(pokles, 0.25, na.rm=T), #dolni kvartil
            prumer = mean(pokles, na.rm=T),
            median = median(pokles, na.rm=T),
            Q3 = quantile(pokles, 0.75, na.rm=T), #horni kvartil
            maximum = max(pokles, na.rm=T),
            rozptyl = var(pokles, na.rm=T),
            smerodatna_odchylka = sd(pokles,na.rm=T),
            variacni_koeficient = (100*(smerodatna_odchylka/prumer)), 
            sikmost = (moments::skewness(pokles, na.rm=T)),
            stand_spicatost = (moments::kurtosis(pokles, na.rm=T)-3),
            dolni_mez_hradeb = Q1-1.5*(Q3-Q1),
            horni_mez_hradeb = Q3+1.5*(Q3-Q1))

t(moje_tab)

0.14687500 - 2*(5.71225274)
0.14687500 + 2*(5.71225274)

poklesab = read_excel("poklesab.xlsx")  # Uprav soubor, p��p. cestu k souboru

poklesab$vyrobce = factor(poklesab$vyrobce, 
                              levels = c("Amber", "Bright"),
                              labels = c("V�robce Amber", "V�robce Bright"))

#krabicovy graf, puvodni data
ggplot(poklesab, # uprav
       aes(x = vyrobce,
           y = pokles))+  # uprav
  stat_boxplot(geom = "errorbar",
               width = 0.15)+
  geom_boxplot()+
  labs(x = "", y = "pokles sv�teln�ho toku po 30 sekund�ch od zapnut� \np�i sn�en� okoln� teploty z 22�C na 5�C (lm)")+ # uprav
  theme_light()+
  theme(axis.ticks.x = element_blank(),
        axis.text = element_text(color = "black", size = 11))

poklesab_nooutliers = read_excel("poklesab_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

poklesab_nooutliers$vyrobce = factor(poklesab_nooutliers$vyrobce, 
                          levels = c("Amber", "Bright"),
                          labels = c("V�robce Amber", "V�robce Bright"))

#krabicovy graf, data po odstraneni odlehlych pozorovani
ggplot(poklesab_nooutliers, # uprav
       aes(x = vyrobce,
           y = pokles))+  # uprav
  stat_boxplot(geom = "errorbar",
               width = 0.15)+
  geom_boxplot()+
  labs(x = "", y = "pokles sv�teln�ho toku po 30 sekund�ch od zapnut� \np�i sn�en� okoln� teploty z 22�C na 5�C (lm)")+ # uprav
  theme_light()+
  theme(axis.ticks.x = element_blank(),
        axis.text = element_text(color = "black", size = 11))

#histogram, puvodni data
ggplot(poklesab, # uprav
       aes(x = pokles))+ # uprav
  geom_histogram(binwidth = 5, # uprav
                 color = "black",
                 fill = "grey55")+
  labs(x = "pokles sv�teln�ho toku po 30 sekund�ch od zapnut� \np�i sn�en� okoln� teploty z 22�C na 5�C (lm)", y = "�etnost")+ # uprav
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce",  # uprav
             dir = "v")

#qqgraf, puvodni data
ggplot(poklesab, # uprav
       aes(sample = pokles))+ # uprav
  stat_qq()+
  stat_qq_line()+
  labs(x = "norm. teoretick� kvantily", y = "v�b�rov� kvantily")+
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce", # uprav
             ncol = 1, # uprav
             scales = "free")

#histogram, data po odstraneni odlehlych pozorovani
ggplot(poklesab_nooutliers, # uprav
       aes(x = pokles))+ # uprav
  geom_histogram(binwidth = 5, # uprav
                 color = "black",
                 fill = "grey55")+
  labs(x = "pokles sv�teln�ho toku po 30 sekund�ch od zapnut� \np�i sn�en� okoln� teploty z 22�C na 5�C (lm)", y = "�etnost")+ # uprav
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce",  # uprav
             dir = "v")

#qqgraf, data po odstraneni odlehlych pozorovani
ggplot(poklesab_nooutliers, # uprav
       aes(sample = pokles))+ # uprav
  stat_qq()+
  stat_qq_line()+
  labs(x = "norm. teoretick� kvantily", y = "v�b�rov� kvantily")+
  theme_light()+
  theme(axis.text = element_text(color = "black", size = 11))+
  facet_wrap("vyrobce", # uprav
             ncol = 1, # uprav
             scales = "free")
