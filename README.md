

# Obiettivo

- L'obietto di questo Proof of Concept è quello di dimostrare concretamente le prorie conoscenze su un progetto minimale ma completo.
- Utilizzare nella scrittura del backend le metodologie e tecniche che si conoscono per implementare un'applicazione robusta e scalabile.
  Si discuterà delle scelte tecnologiche e architetturali.
- Dove l'implementazione risultasse troppo lunga o complessa, sostituire con Fake/Mock/Commenti che ne simulano o spiegano il concetto.
- Il codice finale dovrà essere caricato su questo repository che può essere utilizzato anche durante la fase di sviluppo gli avanzamenti.

# Funzionalità

- Lo scopo dell'applicazione è la gestione della raccolta degli pneumatici fuori uso dei gommisti da parte di un'azienda Intermediaria.
- L'accesso deve essere soggetto ad autenticazione.
- I gommisti possono inserire nuove richieste e vedere le proprie richieste precedenti (stato Ricevuta)
- Il backoffice vede le richieste di tutti i gommisti, le assegna ad un fornitore ed indica una data di ritiro (stato InCorso).
- Dopo che il trasportatore ha effettuato il ritiro dal gommista, viene registrato dal backoffice sulla richiesta evasa, il peso effettivo degli pneumatici. (stato Evasa)

# Regole

- Il gommista può aprire una sola richiesta alla volta. Solo quando la richiesta precedente è Evasa, può inserirne una nuova.
- La quantità minima per aprire una richiesta è 1000, il massimo 9500
- Allo stesso trasportatore non si possono assegnare più di 3 richieste.

# Dominio

- Anagrafiche Gommisti e Trasportatori: Ragione Sociale, Indirizzo
- Richiesta: Gommista, Data Richiesta, Peso da ritirare, Stato
- Stato Richiesta: Ricevuta, InCorso, Evasa

# Requisiti tecnici

- L'applicazione deve essere fruita da web tramite browsert su pc desktop (non è necessario prevedere l'uso su smartphone)
- Deve essere composta da un backend ed un frontend.
- Il backend DEVE essere con tecnologia asp.net core 8/9 con linguaggio C#. 
- Il Frontend a piacere (Angular, Blazor, Vue, JavaScript, ecc). Non sarà oggetto di valutazione.
- L'autenticazione deve solo garantire che l'accesso sia protetto. Va bene qualunque tecnica.
- Persistenza a piacere ( MsSql, PostGres, InMemory, Files, ecc)



