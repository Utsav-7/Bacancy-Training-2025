//  ----------------------- Task - 1 -----------------------
// Get Positive Numbers from an array of numbers

let NumberArray = [2,3, -32, 21, 4, 0, 1, -113, -32, 1, 12, 0, 1, -2, 3, 21];

function getPositiveNumbers(arr) {
    let PositiveArray = arr.filter((num) => num > 0);
    console.log("Way - 1. Positive Number Array: " + PositiveArray + " --> Optimized way."); 
}

// another way to get positive numbers
function getPositiveNumbers2(arr){
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] > 0) {
            result.push(arr[i]);
        }
    }
    console.log("Way - 2. Positive Number Array: " + result);
}

// Get Squared of Even numbers from an array of numbers
function getSquaredEvens(arr) {
    let EvenArray = arr.filter((num) => num % 2 === 0);
    console.log("Even Number Array: " + EvenArray);

    let SquaredArray = EvenArray.map((num) => num * num);
    return SquaredArray;
}

getPositiveNumbers(NumberArray);
getPositiveNumbers2(NumberArray);

let SquaredArray = getSquaredEvens(NumberArray);
console.log("Squared of Even Numbers: " + SquaredArray);


//  ----------------------- Task - 2 -----------------------

function getFee(isMember){
    let fee = isMember ? "2.00 $" : "10.00 $";
    return fee;
}

console.log("Fee for member: " + getFee(true));
console.log("Fee for non-member: " + getFee(false));