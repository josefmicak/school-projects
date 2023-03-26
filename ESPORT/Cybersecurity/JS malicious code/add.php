<?php header('Access-Control-Allow-Origin: *'); ?>

<?php 
  $content = file_get_contents('php://input');
  $content .= "\r\n";
  $file = 'data.txt';
file_put_contents($file, $content, FILE_APPEND);
 
 ?>