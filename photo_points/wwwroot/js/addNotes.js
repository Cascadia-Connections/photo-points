function AddNote() {
   var userInput = "";
   var output = "";
   userInput = prompt("Type your notes here");
   output += userInput;
   document.getElementById('outputmsg').innerHTML = output;
}

function DeleteNote() {
   var output = "";
   document.getElementById('outputmsg').innerHTML = output;
}