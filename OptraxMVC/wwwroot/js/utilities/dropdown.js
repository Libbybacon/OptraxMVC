
export const multiOpts = {
    removeItems: true,
    removeItemButton: true,
    duplicateItemsAllowed: false,
    delimiter: ',',
    resetScrollPosition: true,
    shouldSort: true,
    shouldSortItems: true,
    placeholder: true,
    placeholderValue: '---- Select ----',
    addItemText: (value) => {
        return `Press Enter to add <b>"${value}"</b>`;
    },
    removeItemIconText: () => `X`,
    removeItemLabelText: (value) => `X`,
    maxItemText: (maxItemCount) => {
        return `Only ${maxItemCount} values can be added`;
    },
    valueComparer: (value1, value2) => {
        return value1.toLowerCase().replace(' ', '') === value2.toLowerCase().replace(' ', '');
    },
    callbackOnInit: function () {
        const placeholder = this.containerInner.element.querySelector('.choices__input--cloned');

        const togglePlaceholder = () => {
            const selectedItems = this.getValue();
            if (placeholder) {
                placeholder.style.display = selectedItems.length > 0 ? 'none' : '';
            }
        };
        togglePlaceholder();

        this.passedElement.element.addEventListener('change', togglePlaceholder);
    }
}

export const singleOpts = {
    resetScrollPosition: true,
    shouldSort: true,
    shouldSortItems: true,
    placeholder: true,
    placeholderValue: '---- Select ----',
    callbackOnInit: function () {

        //const placeholder = this.containerInner.element.querySelector('.choices__input--cloned');

        //const togglePlaceholder = () => {
        //    const selectedItems = this.getValue();
        //    if (placeholder) {
        //        placeholder.style.display = selectedItems.length > 0 ? 'none' : '';
        //    }
        //};
        //togglePlaceholder();

        //this.passedElement.element.addEventListener('change', togglePlaceholder);
    }
};