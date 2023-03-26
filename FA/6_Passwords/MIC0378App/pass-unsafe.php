<?php
    $difficulty = intval($_POST['difficulty']);
    $guessedPassword = strval($_POST['guessedPassword']);
    $correctPasswordArray = array("5612", "32276", "bzcd", "h4b2", "z+1c");
    $correctPassword = $correctPasswordArray[$difficulty];
    $result = 'KO';
    if($guessedPassword == $correctPassword){
        $result = 'OK';
    }
    echo $result;
?>