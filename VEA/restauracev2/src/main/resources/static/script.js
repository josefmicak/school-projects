function personTypeSelectChanged(){
	var personType = document.getElementById("personType").value;
	if(personType == 'employee'){
		document.getElementById('salary').disabled = false;
		document.getElementById('address').disabled  = true;
	}
	else{
		document.getElementById('salary').disabled = true;
		document.getElementById('address').disabled  = false;
	}
	
}