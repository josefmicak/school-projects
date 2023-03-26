library(readxl)
library(dplyr)
library(tidyr)
library(ggplot2)
library(ggpubr)
library(moments)
library(rstatix)

setwd("...")

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

moments::skewness(poklesa_nooutliers$pokles)   # �ikmost 
moments::kurtosis(poklesa_nooutliers$pokles)-3 # standardizovan� �pi�atost
shapiro.test(poklesa_nooutliers$pokles)
symmetry.test(poklesa_nooutliers$pokles, boot = FALSE) #todo: could not find?

mean(poklesa_nooutliers$pokles)
t.test(poklesa_nooutliers$pokles, alternative = "greater", conf.level = 0.95)

moments::skewness(poklesb_nooutliers$pokles)   # �ikmost 
moments::kurtosis(poklesb_nooutliers$pokles)-3 # standardizovan� �pi�atost
shapiro.test(poklesb_nooutliers$pokles)
symmetry.test(poklesa_nooutliers$pokles, boot = FALSE)

mean(poklesb_nooutliers$pokles)
t.test(poklesb_nooutliers$pokles, alternative = "greater", conf.level = 0.95)

#c)
poklesab_nooutliers = read_excel("poklesab_nooutliers.xlsx")  # Uprav soubor, p��p. cestu k souboru

podklady = 
  poklesab_nooutliers %>% 
  group_by(vyrobce) %>% 
  summarise(rozsah = length(na.omit(pokles)),
            sikmost = moments::skewness(pokles, na.rm = T),
            spicatost = moments::kurtosis(pokles, na.rm = T)-3, 
            rozptyl = var(pokles, na.rm = T),
            sm_odch = sd(pokles, na.rm = T),
            prumer = mean(pokles, na.rm = T),
            median = quantile(pokles, 0.5, na.rm = T),
            Shapiruv_Wilkuv_phodnota = shapiro.test(pokles)$p.value)

# Anal�za p�edpoklad� (normalita pro ka�d� OS)
ggplot(poklesab_nooutliers, 
       aes(x = pokles))+
  geom_histogram(bins = 10)+
  facet_wrap("vyrobce", 
             ncol = 1)

ggplot(poklesab_nooutliers, 
       aes(sample = pokles))+
  stat_qq()+ 
  stat_qq_line()+
  facet_wrap("vyrobce",
             scales = "free")

# �ikmost, �pi�atost, Shapir�v-Wilk�v test - viz podklady

# Anal�za p�edpoklad� -> normalita OK -> shoda rozptyl�?
# Empiricky - pom�r v�b�rov�ch rozptyl� (v�t�� ku men��mu) < 2 ? - viz podklady
32.6/25.5

var.test(poklesab_nooutliers$pokles~poklesab_nooutliers$vyrobce)
# l�pe - kontrolovan�
var.test(poklesab_nooutliers$pokles[poklesab_nooutliers$vyrobce == "Bright"], 
         poklesab_nooutliers$pokles[poklesab_nooutliers$vyrobce == "Amber"])

# Dvouv�b�rov� t-test (H0: mu_W - mu_L = 0, HA: mu_W - mu_L != 0)
t.test(poklesab_nooutliers$pokles[poklesab_nooutliers$vyrobce == "Amber"], 
       poklesab_nooutliers$pokles[poklesab_nooutliers$vyrobce == "Bright"],
       alternative = "two.sided", 
       var.equal = TRUE, 
       conf.level = 0.95)

1.851562 - 0.146875