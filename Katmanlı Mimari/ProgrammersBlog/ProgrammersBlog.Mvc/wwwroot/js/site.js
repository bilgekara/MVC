// ilk harfi buyuk harfe cevir
// - ilk harfi al ->cevir + verilen indexten itibaren stringi dondurur
function convertFirstLetterToUpperCase(text) {
    return text.charAt(0).toUpperCase() + text.slice(1);
}
// datetime verileri jsondan parse ettigimizde bizlere bir string donuyor
function convertToShortDate(dateString) {
    // stringi date donusturuyoruz projemizdeki formata formatliyoruz
    const shortDate = new Date(dateString).toLocaleDateString('en-US');
    return shortDate;
}