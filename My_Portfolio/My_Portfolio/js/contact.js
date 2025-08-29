document.addEventListener('DOMContentLoaded', function () {
    const inputs = document.querySelectorAll('.input, .textarea');

    inputs.forEach(input => {
        input.addEventListener('blur', () => { // Check on focus out
            if (input.value.trim() === "") {
                input.classList.add('invalid');
                input.classList.remove('valid');
            } else {
                input.classList.add('valid');
                input.classList.remove('invalid');
            }
        });
    });
});
