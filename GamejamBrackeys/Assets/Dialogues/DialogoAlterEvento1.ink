EXTERNAL getName()
VAR characterName = ""
~characterName = getName()
VAR opcionesDialogo = 0
VAR preguntasCounter = 0

->Introductions
===Introductions===
<i>That face seems familiar.</i>#speaker:you #portrait:you
Hey, it's me, {characterName}, I've already got all the resources we needed, open the door. #speaker:{characterName} #portrait:otherPerson

Glad to see you back.#speaker:you #portrait:you
Before letting you in, I have to ask you a couple of questions.
Nothing personal, just protocol.

->selector
===selector===
{
    -preguntasCounter < 2:
        Tell me, {characterName}...#speaker:you #portrait:you
        ->main
    -else:
        ->decisionFinal
}

->main
===main===
*What happened to your partner? #speaker:you #portrait:you
    ~preguntasCounter++
    I had to kill him. I thought he was another alt.#speaker:{characterName} #portrait:otherPerson
    ->selector

*Aren't you back too soon? #speaker:you #portrait:you
    ~preguntasCounter++
    I got lucky and got everything fast.#speaker:{characterName} #portrait:otherPerson
    ->selector
    
*There's a lot of resources missing. #speaker:you #portrait:you
    ~preguntasCounter++
    I ate some of it. I didn't want to starve to death.#speaker:{characterName} #portrait:otherPerson
    ->selector

===decisionFinal===
<i>It's time to make a decision</i> #speaker:you #portrait:you
<i>Open the door?</i> //if not, make this with tag
*[Yes]
    ~temp tyLines = RANDOM(1,100)
    {
        -tyLines>0 && tyLines<=25:
            Thank you, I thought it was the end of me.#pasar:yes #speaker:{characterName} #portrait:otherPerson
        -tyLines>25 && tyLines<=50:
            I'll get to live one more day#pasar:yes #speaker:{characterName} #portrait:otherPerson
        -tyLines>50 && tyLines<=75:
            Thank goodness...#pasar:yes #speaker:{characterName} #portrait:otherPerson
        -else:
            It's about time#pasar:yes #speaker:{characterName} #portrait:otherPerson
    }
    ->END
    
*[No]
    ~temp noLines = RANDOM(1,100)
    {
        -noLines>0 && noLines<=25:
            What do you mean I can't come in? #speaker:{characterName} #portrait:otherPerson
            You can't do this to me!
            What am I suppossed to do now?!#pasar:no
        -noLines>25 && noLines<=50:
            No, no, no, please. #speaker:{characterName} #portrait:otherPerson
            Please reconsider, you're making a mistake.
            Please!!#pasar:no
        -noLines>50 && noLines<=75:
            What? #speaker:{characterName} #portrait:otherPerson
            Well... Who even needs this filthy bunker?!
            I'll manage perfectly by myself.#pasar:no
        -else:
            <i>Starts sobbing uncontrollably. Can't even form a coherent sentence.</i>#pasar:no #speaker:{characterName} #portrait:otherPerson
    }
    <i>This job never gets easier</i> #speaker:you #portrait:you

->END