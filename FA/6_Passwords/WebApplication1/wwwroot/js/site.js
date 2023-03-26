function crackPassword() {
    document.getElementById('guessedPassword').innerHTML = '123';
    document.forms[0].submit();
    var result = document.getElementById('message').innerHTML;
    console.log(result);
}