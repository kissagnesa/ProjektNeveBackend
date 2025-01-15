function Regisztracio(){
  let salt=GenerateSalt(64);
  document.getElementById("regisztracioDatuma").value=Date.now();
  let body={
    "id": document.getElementById("id").value,
    "felhasznaloNev": document.getElementById("felhasznaloNev").value,
    "teljesNev": document.getElementById("teljesNev").value,
    "salt": salt,
    "hash": sha256(sha256(document.getElementById("jelszo").value+salt)),
    "email": document.getElementById("email").value,
    "jogosultsag": document.getElementById("jogosultsag").value,
    "aktiv": document.getElementById("aktiv").value,
    "regisztracioDatuma": document.getElementById("regisztracioDatuma").value,
    "profilKepUtvonal": document.getElementById("profilKepUtvonal").value
  }
  console.log(body);
}
