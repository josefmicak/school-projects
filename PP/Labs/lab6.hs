import System.Win32 (lOCALE_NAME_MAX_LENGTH)
import Data.Text (toUpper)
import Data.Char ()

length' :: Foldable t => t a -> Int
length' x = foldl (\x y -> x+1) 0 x

zipThem :: [a] -> [b] -> [(a,b)]
zipThem _ [] = []
zipThem [] _ = []
zipThem (x:xs) (y:ys) = (x,y) : zipThem xs ys
--nebo:
--zipThem _ _ = []

dotProduct :: [a] -> [b] -> [(a,b)]
dotProduct [] _  = []
dotProduct (x:xs) ys = tmp x ys ++ dotProduct xs ys where
  tmp x [] = []
  tmp x (y:ys) = (x,y) : tmp x ys

--pro první prvek?
--dotProduct :: [a] -> [b] -> [(a,b)]
--dotProduct
 -- tmp x [] = []
  --tmp x (y:ys) = (x,y) : tmp x ys

--allToUpper :: String -> String
--allToUpper [] = []
--allToUpper (x:xs) = toUpper x : toUpper xs

quicksort :: (Ord a) => [a] -> [a]
quicksort [] = []
--quicksort (x:xs) = quicksort (filter (<=x)++[x]++ quicksort xs (filter (>x) xs))
--nebo
quicksort (x:xs) = let
  lp = quicksort (filter (<=x) xs)
  rp = quicksort (filter (>x) xs)
  in lp ++ [x] ++ rp

oddList :: Int -> Int -> [Int]
oddList a b = [x | x <- [a..b], odd x]

--countThem :: String -> [(Char, Int)]
--countThem x = helpFunc x 

unique [] = []
unique (x:xs) = x : unique (filter(/=x) xs)

unique' [] keys = keys
unique' (x:xs) keys | x `elem` keys = unique' xs keys
                    | otherwise = unique' xs (x:keys)

--countThem :: String -> [(Char, Int)]
--countThem xs = [(x,1) | x<- unique xs] pro kazdy da vysledek 1
--countThem xs = [x, length(filter (==x) xs)) | x<- unique xs]

isPrime n = null [x |x<-[2..truncate ((sqrt.fromIntegral) n)], n `mod` x == 0]

goldbach :: Int-> [(Int, Int)]
goldbach n = let 
    --primes = [x | x<- [2..n-1], isPrime x] vypise vsechna prvocisla
    primes = [x | x<- [2..n-1], isPrime x]
  in [(x, n-x) |x<-primes, elem(n-x) primes, x <=n `div` 2]--je elem(n-x) elementem primes?
  --du goldbachList

combinations :: Int -> String -> [String]
combinations 1 xs = [[x] | x<- xs]
combinations n (x:xs) | length (x:xs) == n =[x:xs]
                  | otherwise = [x:c |c<- combinations (n-1) xs] ++ --pridat? combinations n xs