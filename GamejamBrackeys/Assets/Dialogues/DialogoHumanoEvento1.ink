EXTERNAL getName()
VAR characterName = ""
VAR opcionesDialogo = 0
VAR preguntasCounter = 0

->Introductions
~characterName = getName()
===Introductions===
<i>That face seems familiar.</i>
Hey, it's me, {characterName}, I've already got all the resources we needed, open the door

Glad to see you back.
Before letting you in, I have to ask you a couple of questions.
Nothing personal, just protocol.

->selector
===selector===
{
    -preguntasCounter < 2:
        ->main
    -else:
        ->decisionFinal
}

->main
===main===
*What happened to your partner?
    He died... Although, well, I guess he's in a better place now....
    ->selector

*Aren't you back too soon?
    They killed my partner so I had to come back early.
    ->selector
    
*There's a lot of resources missing.
    I gave some of the resources to a family that needed it more than we did.
    ->selector

===decisionFinal===
<i>It's time to make a decision</i>
<i>Open the door?</i> //if not, make this with tag
*[Yes]
    ~temp tyLines = RANDOM(1,100)
    {
        -tyLines>0 && tyLines<=25:
            Thank you, I thought it was the end of me.#pasar:yes
        -tyLines>25 && tyLines<=50:
            I'll get to live one more day#pasar:yes
        -tyLines>50 && tyLines<=75:
            Thank goodness...#pasar:yes
        -else:
            It's about time#pasar:yes
    }
    ->END
    
*[No]
    ~temp noLines = RANDOM(1,100)
    {
        -noLines>0 && noLines<=25:
            What do you mean I can't come in?
            You can't do this to me!
            What am I suppossed to do now?!#pasar:no
        -noLines>25 && noLines<=50:
            No, no, no, please.
            Please reconsider, you're making a mistake.
            Please!!#pasar:no
        -noLines>50 && noLines<=75:
            What?
            Well... Who even needs this filthy bunker?!
            I'll manage perfectly by myself.#pasar:no
        -else:
            <i>Starts sobbing uncontrollably. Can't even form a coherent sentence.</i>#pasar:no
    }
    <i>This job never gets easier</i>

->END