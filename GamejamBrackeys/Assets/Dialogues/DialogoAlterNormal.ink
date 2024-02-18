EXTERNAL getName()
VAR characterName = ""
~characterName = getName()
VAR opcionesDialogo = 0
VAR preguntasCounter = 0

->Introductions
===Introductions===
<i>Here we go again.</i>
~temp introLine = RANDOM(1,96)
{
    -introLine>0 && introLine<=16:
        Please, I need to get in there. I don't want to die.
    -introLine>16 && introLine<=32:
        Is there still room in the bunker? Please...
    -introLine>32 && introLine<=48:
        This is the bunker, isn't it? Open the door, please.
    -introLine>48 && introLine<=64:
        The street is full of monsters... Please, help me.
    -introLine>64 && introLine<=80:
        Please help me! Let me in!
    -else:
        Please, I have nowhere to go...
}

First, I need you to introduce yourself.
After that, I'm going to have to ask you a couple of questions.
Understand?

~temp whineLine = 0
~whineLine= RANDOM(1,96)
{
    -whineLine>0 && whineLine<=16:
        I guess... Whatever it takes to get inside the bunker.
    -whineLine>16 && whineLine<=32:
        What is this, an interrogation?
    -whineLine>32 && whineLine<=48:
        Of course.
        I'll do whatever you ask me to, just get me inside that bunker.
    -whineLine>48 && whineLine<=64:
        What, you think I'm one of those beasts?
        Unbelievable. I'll prove you otherwise.
    -whineLine>64 && whineLine<=80:
        Uhm... Okay, but quick, it's noot safe out here.
    -else:
        Yeah, yeah, whatever. Let's get this over with.
}

My name is {characterName}.

->selector
===selector===
{
    -preguntasCounter < 3:
        Tell me, {characterName}...
        ->main
    -else:
        ->decisionFinal
}

->main
===main===
*Can you whistle?
~preguntasCounter++
~opcionesDialogo = RANDOM(1,100)
{
    -opcionesDialogo>0 && opcionesDialogo<=20:
        ->P1R1
    -opcionesDialogo>20 && opcionesDialogo<=60:
        ->P1R2
    -else:
        ->P1R3
}

*[Have you ever killed anyone?]
Have you ever killed anyone? If so, how many?
    ~preguntasCounter++
    ~opcionesDialogo = RANDOM(1,100)
    {
        -opcionesDialogo>0 && opcionesDialogo<=10:
            ->P2R1
        -opcionesDialogo>10 && opcionesDialogo<=60:
            ->P2R2
        -else:
            ->P2R3
    }
    
*Do you believe in God?
    ~preguntasCounter++
    ~opcionesDialogo = RANDOM(1,99)
    {
        -opcionesDialogo>0 && opcionesDialogo<=33:
            ->P3R1
        -opcionesDialogo>33 && opcionesDialogo<=66:
            ->P3R2
        -else:
            ->P3R3
    }

*[Would sacrifice yourself?]
Would you be willing to sacrifice yourself for the good of the bunker if necessary?
    ~preguntasCounter++
    ~opcionesDialogo = RANDOM(1,100)
    {
        -opcionesDialogo>0 && opcionesDialogo<=30:
            ->P4R1
        -opcionesDialogo>30 && opcionesDialogo<=80:
            ->P4R2
        -else:
            ->P4R3
    }


		
===P1R1===
I prefer not to try.
->selector
===P1R2===
I don't know how to whistle.
->selector
===P1R3===
I can't whistle.
My teeth are too far apart, so when I blow I can't make any noise.
->selector

===P2R1===
No, I haven't killed anyone.  
->selector
===P2R2===
~temp peopleKilled = RANDOM(3, 15)
I've killed {peopleKilled} times.
->selector
===P2R3===
~temp peopleKilled = RANDOM(5, 31)
Honestly, yes.
I've killed {peopleKilled} people since the start of this chaos.
->selector


===P3R1===
Are there still people who believe in an all-powerful deity capable of protecting people from all evils?
Heh... How ridiculous  
->selector
===P3R2===
I would never believe in something as absurd as a God.
->selector
===P3R3===
I am an atheist, I have never believed in any God.
->selector


===P4R1===
No. My life comes before the lifes of others.
->selector
===P4R2===
Of course not! I want to enter the bunker to survive, not to sacrifice myself!
->selector
===P4R3===
A human should always be able to sacrifice himself for the community if necessary.
Otherwise we would just be selfish beasts.

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
