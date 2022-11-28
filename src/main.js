//the layout represents the weights per column of the network
let netLayout = [1, 4, 4, 1];
//the network let contains the values of all network weights
let net = "1234567891011121314151617181920212223242526272829";

//I'm using charInString as a shared counter when running the network. It tells the network which letacter in the let it's on
let charInString = 0;
//same with column
let column = 0;

 function Run(inputs) {
    inputs = AddWeights(inputs, 0);
    
    if (netLayout.length != column+1)
    {
        let newInputs = [netLayout[column+1]];
        inputs = AddBiases(inputs, newInputs, 0, 0);
    }
    //my first ever recursive program! (I had 4 nested for loops)
    column++;
    if (column >= netLayout.length) {
        charInString = 0;
        column = 0;
        return inputs;
    }
    return Run(inputs);
}

function AddWeights(inputs, weightNum) {
    let c = net.charAt(charInString);
    charInString++;
    inputs[weightNum] *= parseInt(c);
    console.log(c,inputs, 'adding weights');

    weightNum++;
    if (weightNum >= netLayout[column]) {
        return inputs;
    }
    return AddWeights(inputs, weightNum);
}


 function AddBiases(inputs, newInputs, weightNum, biasNum) {
    newInputs[biasNum] = 0;
    let c = net.charAt(charInString);
    charInString++;
    newInputs[biasNum] += parseInt(c) + inputs[weightNum]; 
    console.log(c,newInputs, 'adding biases');

    biasNum++;
    if (biasNum >= netLayout[column+1]) {
        weightNum++;
        biasNum = 0;
        if (weightNum >= netLayout[column]) {
            return newInputs;
        }
    }
    return AddBiases(inputs, newInputs, weightNum, biasNum);

}

//mutates the network string
 function Mutate(mutRate, maxMutChange) {
    let newNet = "";
    let rnd = Math.random();
    for (let i = 0; i < net.length; i++)
    {
        /* This mutates any let, other code mutates into int from 0-9
        let c = net[i];
        if (rnd.Next(1, mutRate) == 1)
        {
            //adds value to let
            c += (let) rnd.Next(-maxMutChange, maxMutChange);
        }
        newNet += c;
        */
        let c = net.charAt(i);
        if (rnd.Next(1, mutRate) == 1)
        {
            let cValue = parseInt(c + rnd.Next(-maxMutChange, maxMutChange));
            if (cValue >= 0 && cValue <= 9) {
                newNet += cValue;
            }
        }
        
        //console.log(newNet);
    }
    net = newNet;
}

 function CreateDiagram(inputs) {
    let charInString = 0;
    for (let column = 0; column < netLayout.length; column++)
    {
        for (let i = 0; i < netLayout[column]; i++)
        {
            let c = net.charAt(charInString);
            charInString++;
            inputs[i] *= parseInt(c);
            
        }

        if (netLayout.length != column+1)
        {
            let newInputs = [netLayout[column+1]];
            for (let row = 0; row < netLayout[column]; row++)
            {
                //I know this nested loop layout isn't at all readable, but I'm lazy and don't want to split it into seperate functions
                for (let bias = 0; bias < netLayout[column+1]; bias++)
                {
                    newInputs[bias] = 0;
                    let c = net.charAt(charInString);
                    charInString++;
                    newInputs[bias] += parseInt(c); 
                    console.log(c);
                }
            }
            inputs = newInputs;
        }
    }
}


console.log(Run([1])[0])
CreateDiagram([1])