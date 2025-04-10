export const shared = {
    resetScrollPosition: true,
    shouldSort: true,
    shouldSortItems: true,
    placeholder: true,
    placeholderValue: '---- Select ----',
    noChoicesText: 'No options',
    itemSelectText: '',
}


export const multiOpts = {
    ...shared,
    removeItems: true,
    removeItemButton: true,
    duplicateItemsAllowed: false,
    delimiter: ',',

    addItemText: (value) => {
        return `Press Enter to add <b>"${value}"</b>`;
    },
    removeItemIconText: () => `x`,
    removeItemLabelText: (value) => `x`,
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
    ...shared,
    callbackOnInit: function () {
        $('.choices__inner').addClass('form-select');
        $('.range .choices').addClass('flex-fill');
    }
};