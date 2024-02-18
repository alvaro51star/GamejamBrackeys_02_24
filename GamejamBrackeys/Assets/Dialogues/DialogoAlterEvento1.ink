EXTERNAL getName()
VAR characterName = ""
~characterName = getName()
VAR opcionesDialogo = 0
VAR preguntasCounter = 0

->Introductions
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
Tell me, {characterName}...
*What happened to your partner?
    I had to kill him. I thought he was another alt.
    ->selector

*Aren't you back too soon?
    I got lucky and got everything fast.
    ->selector
    
*There's a lot of resources missing.
    I ate some of it. I didn't want to starve to death.
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