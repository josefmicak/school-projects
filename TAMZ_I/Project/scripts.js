//ELEMENTS
const refreshButton = document.getElementById('controlsRefreshButton');
const muteButton = document.getElementById('controlsMuteButton');

//VARIABLES
const cards = document.querySelectorAll('.card');
let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;
var moves = 0;
var remaining = 16;
var mykey = 0; 
var clickSound = new sound("sounds/click.mp3");
var successSound = new sound("sounds/success.wav");
var failSound = new sound("sounds/fail.wav");
var isMuted = false;

refreshButton.addEventListener('click', refreshPage);
muteButton.addEventListener('click', switchSound);

window.onload = newGame();
window.onload = showHighscores();

//GAME FUNCTIONS
function newGame(){	
	updateMoves();
	updateRemaining();	
	setTimeout(() => {  shuffle(); }, 500);	
	resetBoard();	
	cards.forEach(card => card.addEventListener('click', flipCard));
}

function refreshPage(){
	moves = 0;
	remaining = 16;
	cards.forEach(card => {
		card.classList.remove('flipped');
	});
	newGame();
}

//CARD FUNCTIONS
function flipCard() {
	if (lockBoard) return;
	if (this === firstCard) return;

	this.classList.add('flipped');

	if (!hasFlippedCard) {
		hasFlippedCard = true;
		firstCard = this;
		if(!isMuted)
		{
			clickSound.play();
		}
		moves++;
		updateMoves();
		return;
	}

	secondCard = this;
	lockBoard = true;
	if(!isMuted)
	{
		clickSound.play();
	}
	moves++;
	updateMoves();

	checkForMatch();
}

function checkForMatch() {
	if (firstCard.dataset.card === secondCard.dataset.card) {
		if(!isMuted)
		{
			setTimeout(() => {  successSound.play(); }, 500);	
		}
		disableCards();
		remaining -= 2;
		updateRemaining();
		return;
	}
	else
	{
		if(!isMuted)
		{
			setTimeout(() => {  failSound.play(); }, 500);	
		}
	}
	unflipCards();
}

function disableCards() {
	firstCard.removeEventListener('click', flipCard);
	secondCard.removeEventListener('click', flipCard);

	resetBoard();
}

function unflipCards() {
  setTimeout(() => {
    firstCard.classList.remove('flipped');
    secondCard.classList.remove('flipped');

    resetBoard();
  }, 1500);
}
  
function updateMoves()
{
	document.getElementById('moves').innerHTML = moves;
}

function updateRemaining()
{
	document.getElementById('remaining').innerHTML = remaining;
	
	if(remaining == 0)
	{
		alert("You won! Total moves: " + moves);
		mykey = localStorage.length;
		var object = {};
		object.kroku = moves;
		localStorage.setItem(mykey,JSON.stringify(object)); 
		remaining = 16;
	}
}

function resetBoard() {
	[hasFlippedCard, lockBoard] = [false, false];
	[firstCard, secondCard] = [null, null];
}

function shuffle() {
	cards.forEach(card => {
		let ramdomPos = Math.floor(Math.random() * 12);
		card.style.order = ramdomPos;
	});
}

//HIGHSCORES
function showHighscores(){
	const array1 = [];
	array1.length = 5;
	for(var i = 0; i < localStorage.length; i++)
	{
		var myKey = localStorage.key(i);
        var myValue = JSON.parse(localStorage.getItem(myKey));
		array1[i] = myValue.kroku;
	}
	array1.sort(function(a, b){return a - b});
	array1.length = 5;
	
	for(var i = 0; i <= array1.length; i++)
	{
		if(array1[i] > 0)
		{
			var listItem= document.createElement('li');
			listItem.innerHTML = (i + 1) + ". " + array1[i] + " moves"; 
			document.getElementById('highscoresList').appendChild(listItem); 
		}
	}
}

function downloadHighscores(){
	const array1 = [];
	array1.length = 5;
	for(var i = 0; i < localStorage.length; i++)
	{
		var myKey = localStorage.key(i);
        var myValue = JSON.parse(localStorage.getItem(myKey));
		array1[i] = myValue.kroku;
	}
	array1.sort(function(a, b){return a - b});
	array1.length = 5;

	var csvContent = '';

	for(var i = 0; i < array1.length; i++)
	{
		if(array1[i] > 0)
		{
			csvContent += (i + 1) + ". " + ';' + array1[i] + " moves" + '\n';
		}
	}


	var download = function(content, fileName, mimeType) {
    var a = document.createElement('a');
     mimeType = mimeType || 'application/octet-stream';

    if (navigator.msSaveBlob) { 
		navigator.msSaveBlob(new Blob([content], {
        type: mimeType
		}), fileName);
    } else if (URL && 'download' in a) { 
		a.href = URL.createObjectURL(new Blob([content], {
        type: mimeType
    }));
		a.setAttribute('download', fileName);
		document.body.appendChild(a);
		a.click();
		document.body.removeChild(a);
    } else {
		location.href = 'data:application/octet-stream,' + encodeURIComponent(content); // only this mime type is supported
  }
}

download(csvContent, 'highscores.csv', 'text/csv;encoding:utf-8');
}

//SOUND
function sound(src) {
    this.sound = document.createElement("audio");
    this.sound.src = src;
    this.sound.setAttribute("preload", "auto");
    this.sound.setAttribute("controls", "none");
    this.sound.style.display = "none";
    document.body.appendChild(this.sound);
    this.play = function(){
        this.sound.play();
    }
    this.stop = function(){
        this.sound.pause();
    }    
}

function switchSound(){
	isMuted = !isMuted;
		
	if (isMuted) 
	{
		this.classList.add("muted");
	}
	else 
	{
		this.classList.remove("muted");
	}
}

//GEOLOCATION
var x = document.getElementById("location");

(function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition);
  } else { 
    x.innerHTML = "Geolocation is not supported by this browser.";
  }
})();

function showPosition(position) {
  x.innerHTML = "<small>Your location</small><br> " + 
  "Latitude: <b>" + position.coords.latitude + "</b>" + 
  "<br>Longitude: <b>" + position.coords.longitude + "</b>";
}

//DIALOG
var dialog = document.getElementById("dialog");
var openBtn = document.getElementById("footerHighscoresButton");
var closeBtn = document.getElementById("dialogCloseButton");

openBtn.onclick = function() {
	dialog.classList.add("opened");
}

closeBtn.onclick = function() {
	dialog.classList.remove("opened");
}

window.onclick = function(event) {
	if(event.target == dialog) {
		dialog.classList.remove("opened");
	}
}
