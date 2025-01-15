function Regisztracio(){
  let salt=GenerateSalt(64);
  let datum=new Date();
  let body={
    "id": document.getElementById("id").value,
    "felhasznaloNev": document.getElementById("felhasznaloNev").value,
    "teljesNev": document.getElementById("teljesNev").value,
    "salt": salt,
    "hash": sha256(sha256(document.getElementById("jelszo").value+salt)),
    "email": document.getElementById("email").value,
    "jogosultsag": document.getElementById("jogosultsag").value,
    "aktiv": document.getElementById("aktiv").value,
    "regisztracioDatuma": datum.toISOString(),
    "profilKepUtvonal": document.getElementById("profilKepUtvonal").value
  }
  console.log(body);
}