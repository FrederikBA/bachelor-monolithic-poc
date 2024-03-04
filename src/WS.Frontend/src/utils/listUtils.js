const listUtils = () => {

    const stringToNumbers = (stringArr) => {
        let numberArray = [];

        for (let i = 0; i < stringArr.length; i++)

            numberArray.push(parseInt(stringArr[i]));

        return numberArray;
    }

    return {
        stringToNumbers
    }
}

export default listUtils();