$(document).ready(function () {
    /* Data tables start here */
    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        // kategori listesi almak icin, get islemini hangi urle yapicam
                        type: 'GET',
                        url: '/Admin/Category/GetAllCategories/', // @Url.Action("GetAllCategories","Category")
                        contentType: "application/json", //hangi tipte olacak xml de olabilirdi
                        // ajax işlemini yapmadan once yapacaklarımız-> tablomuzun gizlenmesi ve spinner kısmının aktif edilmesi
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        // ajax işlemini yaptilk ve basarili bir sekilde return dondu -> categoryListDto json formatında geldi
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);
                            console.log(categoryListDto);
                            if (categoryListDto.ResultStatus === 0) {
                                let tableBody = "";
                                // categoryListDto kategoriler icinde donmek istiyoruz
                                $.each(categoryListDto.Categories.$values,
                                    function (index, category) {
                                        tableBody += `
                                                <tr>
                                    <td>${category.Id}</td>
                                    <td>${category.Name}</td>
                                    <td>${category.Description}</td>
                                    <td>${convertFirstLetterToUpperCase(category.IsActive.toString())}</td>
                                    <td>${convertFirstLetterToUpperCase(category.IsDeleted.toString())}</td>
                                    <td>${category.Note}</td>
                                    <td>${convertToShortDate(category.CreatedDate)}</td>
                                    <td>${category.CreatedByName}</td>
                                    <td>${convertToShortDate(category.ModifiedDate)}</td>
                                    <td>${category.ModifiedByName}</td>
                                    <td>
                                         <button class="btn btn-primary btn-sm btn-block btn-update" data-id="${category.Id}"><span class="fas fa-edit"></span> </button>
                                         <button class="btn btn-danger btn-sm btn-block btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span> </button>
                                    </td>
                                        </tr>`;
                                    });
                                // tablodaki html ile yer degistiriyoruz
                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });
    /* DataTables end here */
    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */
    $(function () {
        const url = '/Admin/Category/Add/';  // @Url.Action("Add", "Category")
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });
        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */
        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */
        /* bu div üzerinde bizim eklicegimiz event tetiklendiginde calisacak islemler */
        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                /* buradaki butonun kendi clint eventini engellemek istiyorum */
                event.preventDefault();
                const form = $('#form-category-add'); /* modul sayfaındaki form */
                const actionUrl = form.attr('action'); /* action urlini okuyoruz - formdaki, bu form tm olarak hangi urle post edilmeli */
                const dataToSend = form.serialize(); /* gönderilecek veriyi formu serilestirerel aldik */
                /* aslinda form icindeki veriyi bi tane categoryAddDto olarak donusturmus olduk
        formdan gerekli verileri aldıgımıza gore bunları gerekli urle post edebiliriz4
        $ -> post işlemini hangi urle yapmaliyim, actionUrl e beyi gondermeliyim(post etmeliyim) -> categoryAddDto yu gerekli urle gonderdim
        done -> bu, islem bittiginde return islemi olcak(category de categoryaddajaxview model return ediyoduk)
data yı json olarak parse ettikten sonra bir javascript objesi icine atiyo olucaz */
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    /* bize gelen datayı okuyabilmek icin jsondan pars ediiyoruz */
                    const categoryAddAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryAddAjaxModel);
                    /* yeni geken partialviewi form model içersine asmalıyız, yani oradaki veriyle buradakini degistimek
                    neden -> biz burda islemleri yaptigimizda(formu doldurduk)
                        - kullanıcı bu bilgileri tam da girmis olabilir bos da bırakabilir,
                            - bir modelstate kontrolu oluyor,
                                - onunla ilgili veriler islendikten sonra bizlere yeni bir partialview donuyor,
                                    - partialview icinde de kontrol sagliyoduk
                                        - eger kullanici valid bir bilgi girmediyse bununla ilgili
                    validasyon mesajları yeni partial view icinde bulunması gerekiyor
                        - yeni partialview kullanıcıya gosterirsek kullanıcı hata yaptiysa bunu da gormus olucak
                            - yeni partialviewi alalım
                                - aslinda formbody yi partialview icerisine kazıyor olucaz(modal - body kısmını secicez)
                                    - modelimiz icerisindeki partialview icinden seviyoruz
                                        */
                    const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                    /* eskisiyle yer degistirelim,
                        modelbudyyi bulduk -> modelbody htmlini yeni partialview deki html ile degistirmek istioduk */
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    /* formumuz icindeki isvalid durumunu yabni orada ekleidigimiz bilgileri oradan almak istiyoruz
                        - newformody üzerindeki ekledigimmiz input kısmını seciyoruz */
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        /* bunu bir modal haline getir ve gizle
                        modal ile gelen yeni dto''yu tablo üzerine eklicem */
                        placeHolderDiv.find('.modal').modal('hide');
                        /* modelin icindeki categoryDTO modeline eristik ve onun icindeki id degerinide buraya yazdirdik */
                        const newTableRow = `
                                <tr>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                                    /* is active bool formatinda oldugu icin donustruduk */
                                                    <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                                    <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsDeleted.toString())}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                                   <button class="btn btn-primary btn-sm btn-block btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span> </button>
                                         <button class="btn btn-danger btn-sm btn-block btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span> </button>

</tr>`;
                        /* table row olusturduk ama string jquery ojesi haline getircez ki jquery kodlarını kullanabilelim */
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        /* yeni satiri tablomuza ekliyor */
                        $('#categoriesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500); /* efektif gelmesini sagliyor - 3, 5 sn */
                        toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Başarılı İşlem!');
                    }
                    else {
                /* validation - summary'yi secmeliyiz, hatali islem yaptigimizda(invalid) orada bir div aciliyor
                div icersinde ul oluyor ve ul icinde li oluyo, li'ler icinde donmeliyiz*/                                let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text(); //icinde bulundugumuz li'yi seciyorız
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });
    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */
    /* Ajax POST / Deleting a Category starts from here */
    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            // id degerini basilmis buton uzeriden yakaliyoruz
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            // ikinci sıradaki td(table datayı) secmek istiyorum
            const categoryName = tableRow.find('td:eq(1)').text();

            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${categoryName}adlı kategori silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id }, // category id olarak id'yi donduruyoruz
                        url: '/Admin/Category/Delete/',
                        success: function (data) {
                            const categoryDto = jQuery.parseJSON(data);
                            if (categoryDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${categoryDto.Category.Name} adlı kategori başarıyla silinmiştir.`,
                                    'success'
                                );
                                tableRow.fadeOut(3500);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${categoryDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });
    $(function () {
        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { categoryId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });
    });
});