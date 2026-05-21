// import { apiService } from "@/service/BaseService";
import { createI18n } from 'vue-i18n';

// Tạo Vue I18n với dữ liệu ngôn ngữ động từ API
const createI18nInstance = async () => {
    // const responseLanguage = await apiService.get('api/language/listbynation'); // Gọi API lấy ngôn ngữ
    const lstLanguages = [
        { "code": "us", "name": "English" },
        { "code": "kr", "name": "Korean" },
    ];

    const lstTranslate = [
        { "lang_code": "us", "key": "greeting", "value": "Hello" },
        { "lang_code": "us", "key": "goodbye", "value": "goodbye" },
        { "lang_code": "kr", "key": "greeting", "value": "Chào" },
        { "lang_code": "kr", "key": "goodbye", "value": "Tạm biệt" },
    ]

    // Tạo messages cho Vue I18n
    const messages = {};

    // lặp danh sách ngôn ngữ
    lstLanguages.forEach(language => {
        // Lưu các chuỗi dịch vào messages
        messages[language.code] = {};

        // Chuyển dữ liệu chuỗi dịch thành đối tượng
        lstTranslate.forEach((translation) => {
            if (translation.lang_code == language.code) {
                messages[language.code][translation.key] = translation.value;
            }
        });

    });

    return createI18n({
        legacy: false, // Cấu hình sử dụng Vue 3 Composition API
        locale: 'kr', // Ngôn ngữ mặc định
        messages, // Cập nhật messages ngôn ngữ từ API
    })
}

export default createI18nInstance;