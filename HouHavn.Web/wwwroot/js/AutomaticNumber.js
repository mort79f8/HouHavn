
let checkBox = document.querySelector(".check-box");
let input = document.querySelector("#Berth_BerthId");
let nextNumber = input.value;

checkBox.addEventListener("click", (e) => {
    if (checkBox.checked) {
        input.value = nextNumber;
    }

})
