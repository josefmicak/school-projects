import Distribution.Simple.Utils (xargs)
factorial :: Int -> Int
actorial 0 = 1
factorial n = n * factorial (n - 1)

fibonacci :: Int -> Int
fibonacci 0 = 1
fibonacci 1 = 1
fibonacci n = fibonacci(n - 1) + fibonacci(n - 2)

fibonacci2 n = step 1 1 n where
    step a b 1 = b --return statement
    step a b n = step b (a+b) (n-1)

leapYear :: Int -> Bool 
leapYear y = y `mod` 400 == 0 || y `mod` 4 == 0 && y `mod` 100 /= 100

--leapYear2 y | y `mod` 400 == True
  --          | y `mod` 100 == 0 = False
    --        | otherwise = y `mod` 400 == 0

max2 :: Int -> Int -> Int
max2 a b 
    | a > b = a
    | otherwise = b

max3 :: Int -> Int -> Int -> Int
max3 a b c
    | a > b = a
    | c > a = c
    | otherwise = b

max2u :: Int -> Int -> Int
max2u x y = if x < y then y else x

max3u :: Int -> Int -> Int -> Int
max3u x y z = max2 (max2 x y) z

gcd' :: Int -> Int -> Int
gcd' x y
    | x > y = gcd' (x-y) y
    | x < y = gcd' x (y - x)
    | otherwise = x

gcd'u :: Int -> Int -> Int
gcd'u a b | a == b = a
          | a < b = gcd' a (b-a)
          | a > b = gcd' (a-b) b

isPrime :: Int -> Bool 
isPrime n = test n (truncate(sqrt (fromIntegral n))) where--nebo floor
    test :: Int -> Int -> Bool--nemusí být?; v test nemusí být n, vezme si jej z outer scope
    test n 1 = True
    test n c | n `mod` c == 0 = False 
             | otherwise = test n (c-1)

sumIt :: [Int] -> Int
sumIt [] = 0
sumIt (x:xs) = x + sumIt xs

getHead :: [a] -> a
getHead (x:xs) = x

getLast :: [a] -> a
getLast (x:xs) = getLast xs

--du - zbytek ze cvika 3, po skalar