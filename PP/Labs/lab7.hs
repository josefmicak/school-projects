import Data.List (sortBy)
import Distribution.Simple.Utils (xargs)

--huffman :: [(Char, Int)] -> [(Char, String)]
huffman xs = tmp [ (x,[(ch,"")])|(ch, x) <- xs]

tmp :: [(Int, [(Char, String)])] -> [(Char, String)]
tmp list =
  let
    sorted = sortBy (\ (x1,_) (x2,_) -> compare x1 x2) list
    add number xs = [ (ch,number:code)|(ch,code)<-xs ]
    join [(_,x)] = x
    join ((a1,a2):(b1,b2):xs) = tmp ((a1+b1, (add '0' a2)++(add '1' b2)) : xs)
  in join sorted

type Pic = [String]

pic :: Pic
pic = [ "....#....",
        "...###...",
        "..#.#.#..",
        ".#..#..#.",
        "....#....",
        "....#....",
        "....#####"]

pp :: Pic -> IO ()
pp x = putStr (concat (map (++"\n") x))

flipV :: Pic -> Pic
flipV x = map reverse x

flipH :: Pic -> Pic
flipH x = reverse x

above :: Pic -> Pic -> Pic
above x y = x ++ y

sideBySide :: Pic -> Pic -> Pic
sideBySide = zipWith (++)

rotateR :: Pic -> Pic
rotateR [x] = lineToRow x
rotateR (x:xs) = rotateR xs `sideBySide` lineToRow x

lineToRow :: String -> Pic
lineToRow line = [[ch]|ch<-line]