import System.Win32 (lOCALE_NAME_MAX_LENGTH)
import Data.Char

--cvičení 3
isElement :: Eq a => a -> [a] -> Bool 
isElement x [] = False 
isElement x (y:ys) | x == y = True 
                   | otherwise = isElement x ys

getTail :: [a] -> [a]
getTail (x:xs) = xs 

getInit :: [a] -> [a]
getInit [x] = []
getInit (x:xs) = x : getInit xs

combine :: [a] -> [a] -> [a]
combine [] y = y
combine (x:xs) y = x : combine xs y

max' :: [Int] -> Int
max' (x:xs) = tmp x xs where
    tmp locMax [] = locMax
    tmp locMax (x:xs) | locMax < x = tmp x xs
                      | locMax >= x = tmp locMax xs

reverse' :: [a] -> [a]
reverse' [] = []
--reverse' (x:xs) = reverse' xs 'combine' [x]špatná řešení, špatná složitost

reverse'' :: [a] -> [a]
reverse'' xs = tmp xs [] where
    tmp [] ys = ys--funkce negeneruje výsledek, schovává ho v parametru, vrátí jej nž na konci
    tmp (x:xs) ys = tmp xs (x:ys)

take' :: Int -> [a] -> [a]
take' 0 _= []
take' n [] = []
take' n (x:xs) = x : take' (n-1) xs

drop' :: Int -> [a] -> [a]
drop' 0 xs = xs
drop' n [] = []
drop' n (_:xs) = drop' (n-1) xs

divisors :: Int -> [Int]
divisors n = tmp n where 
    tmp 1 = [1]
    tmp c | n `mod` c == 0 = c : tmp (c-1)
          | otherwise  = tmp (c - 1)

divisors' :: Int -> [Int]
divisors' n = [x | x<-[1..n], n `mod` x == 0]

--du - zip, dotProduct, , fibonacci, alltoupper, quicksort

addThem :: (Int, Int) -> Int
addThem (x,y) = x + y

zipThem :: [a] -> [b] -> [(a,b)]
zipThem (x:xs) (y:ys) = (x,y) : zipThem xs ys

dotProduct :: [a] -> [b] -> [(a,b)]
dotProduct [] _ = []
dotProduct (x:xs) ys = tmp ys ++ dotProduct xs ys where
  tmp [] = []
  tmp (b:bs) = (x,b) : tmp bs

fibonacci :: Int -> Int
fibonacci n = fst (tmp n) where
  fibStep (a,b) = (b,a+b)
  tmp 0 = (0,1)
  tmp x = fibStep (tmp (x-1))

allToUpper :: String -> String
allToUpper xs = [toUpper x |x<-xs]  

quicksort :: (Ord a) => [a] -> [a]
quicksort [] = []
quicksort (x:xs) = let lp = filter (< x) xs
                       rp = filter (>= x) xs
                   in quicksort lp ++ [x] ++ quicksort rp