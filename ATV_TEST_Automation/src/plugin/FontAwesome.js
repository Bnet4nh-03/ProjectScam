// Import Font Awesome Core
import { library } from '@fortawesome/fontawesome-svg-core';
import { fab } from '@fortawesome/free-brands-svg-icons'; // Bộ icon Brands
import { far } from '@fortawesome/free-regular-svg-icons'; // Bộ icon Regular
import { fas } from '@fortawesome/free-solid-svg-icons'; // Bộ icon Solid
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

// Thêm các bộ icon vào thư viện
library.add(fas, far, fab);


// Export FontAwesomeIcon component để dùng trong Vue
export { FontAwesomeIcon };

