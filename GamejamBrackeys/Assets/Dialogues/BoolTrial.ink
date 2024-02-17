->main
===main===
Hola
¿Me dejas pasar?
    *[Sí]
    ->DejoPasar
    *[No]
    ->NoDejoPasar
    
===DejoPasar===
Gracias! #pasar:yes
->END

===NoDejoPasar===
Jopetas #pasar:no
->END