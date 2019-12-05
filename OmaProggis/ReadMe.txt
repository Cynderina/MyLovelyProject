SQL database https://github.com/Cynderina/MyLovelyProjectDB/blob/master/MyLovelyProjectDB.sql

Tietokannassa on kolme etukäteen tehtyä käyttäjäprofiilia testausta varten, joita suositellaan käytettäväksi testaukseen
Tunnusten nimet (joita ohjelma alussa kysyy), ovat:
Admin
Purchaser
ARSpecialist

Arviointia varten huomioita:

Oliot:
Ohjelmalla käsitellään dokumentteja, jotka ovat joko lasku- tai tilausluokan olioita. 
Luokilla on erilaisia ominaisuuksia, ja ohjelman käyttäjien rooleille on omat luokkansa, 
joille kullekin on määritelty oma metodi käyttäjän menun noutamiseen. 
Tietojen näkyvyyksiin on määritelty rajoituksia (privateja ja internaleja). 
”Order”-luokalla on myös propertynä _purchaser. 

Luokkarakenne:
Kaikilla dokumentti-luokkaan liittyvillä luokilla on kirjoitettu konstruktori, joka tallentaa olioihin liittyvää dataa
jo olion luontivaiheessa. 
Lasku- ja tilausluokat perivät dokumenttiluokan.

Rajapinnat:
Ohjelman pääluokkina toimivat ”Document” ja ”User” nimiset luokat. 
”Purchaser,” ”ARSpecialist” ja ”Admin” ovat ”User”-pääluokan aliluokkia 
ja ”Order” ja ”Invoice” ovat ”Document”-pääluokan aliluokkia. User-luokasta 
löytyy lista ja muuttuja, jotka näkyvät vain kyseisen luokan ja sen aliluokkien sisällä. 
Tietoja hyödynnetään kyseisen luokan aliluokissa tervetuloviestin mukana, joka myös kertoo erääntyneiden laskujen tilanteen.
Käyttäjien tervetuloviestissä on hyödynnetty "Interfacea".


Dokumentointi:
Luokkakaavio toimitettu erillisenä .jpeg-tiedostona moodleen.
Lähdekoodissa on mukana tarkentavia kommentteja. 
Muuttujat ja metodien nimet ovat toimintoja kuvaavia. 
Esimerkiksi pääohjelma kutsuu metodia ”PrintMenu”, joka kutsuu käyttäjän rooliin sopivan valikon tulostuksen.

Tallentaminen:
Esimerkiksi käyttäjät on tallennettu PostgreSQL:llä toteutettuun tietokantaan ja ohjelma tallentaa tietoja sekä hakee tietoja tietokannasta. 
Ohjelma lukee myös tilaukset tietokannasta ja syöttää olioina listaan, kun ohjelma käynnistetään.
Ohjelmalla on myös mahdollista tallentaa tilauksia tietokantaan.



