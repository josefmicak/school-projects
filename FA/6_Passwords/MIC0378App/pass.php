<?php
    if (isset($_POST['submit-btn'])){
        $recaptcha = $_POST['g-recaptcha-response'];
        $secret_key = '6LfvBNsiAAAAABSNl9MJn2B8RjyREkazLyC6iGcJ';
        $url = 'https://www.google.com/recaptcha/api/siteverify?secret='
        . $secret_key . '&response=' . $recaptcha;
        $response = file_get_contents($url);
        $response = json_decode($response);
        if ($response->success == false) {
            echo 'No valid captcha';
        } else {
            $difficulty = intval($_POST['difficulty']);
            $guessedPassword = strval($_POST['guessedPassword']);
            $correctPasswordArray = array("5612", "32276", "bzcd", "h4b2", "z+1c");
            $correctPassword = $correctPasswordArray[$difficulty];
            $result = 'KO';
            if($guessedPassword == $correctPassword){
                $result = 'OK';
            }
            echo $result;
        }
    }
    else{
        echo "Invalid form submission";
    }
?>