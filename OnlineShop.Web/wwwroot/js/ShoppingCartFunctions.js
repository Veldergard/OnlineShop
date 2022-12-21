function MakeUpdateAmountButtonVisible(id, visible) {
    const updateAmountButton = document.querySelector("button[data-itemid=\"" + id + "\"]");

    if (visible == true) {
        updateAmountButton.style.display = "inline-block";
    } else {
        updateAmountButton.style.display = "none";
    }
}