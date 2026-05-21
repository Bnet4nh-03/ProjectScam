<template>
  <div class="custom-autocomplete-container">
    <FloatLabel variant="on">
      <AutoComplete :inputId="inputId" v-model="internalValue" :suggestions="filteredItems"
        :optionLabel="isObjectList ? optionLabel : undefined" dropdown @complete="onSearch" @change="onChange"
        style="width: 100%;" v-bind="$attrs">
        <template #footer v-if="allowAdd">
          <div class="px-3 py-3 border-top-1 surface-border">
            <Button label="Add New" fluid severity="secondary" text size="small" icon="pi pi-plus" @click="onAddNew"
              :disabled="!searchText || isExisting" />
          </div>
        </template>
      </AutoComplete>
      <label v-if="label" class="uppercase tracking-widest" :for="inputId">{{ label }}</label>
    </FloatLabel>
    <small style="color: red" class="p-error" v-if="required && submitted && !internalValue">
      {{ errorText }}
    </small>
  </div>
</template>

<script>
export default {
  inheritAttrs: false
}
</script>

<script setup>
import { ref, computed, watch } from 'vue';

const props = defineProps({
  modelValue: {
    type: [Object, String],
    default: null
  },
  items: {
    type: Array,
    default: () => []
  },
  optionLabel: {
    type: String,
    default: 'label'
  },
  label: {
    type: String,
    default: 'Select Item'
  },
  inputId: {
    type: String,
    default: () => `ac_${Math.random().toString(36).slice(2, 11)}`
  },
  errorText: {
    type: String,
    default: 'It cannot be left blank.'
  },
  submitted: {
    type: Boolean,
    default: false
  },
  required: {
    type: Boolean,
    default: false
  },
  allowAdd: {
    type: Boolean,
    default: true
  }
});

const emit = defineEmits(['update:modelValue', 'update:items', 'add-new']);

const internalValue = ref(props.modelValue);
const filteredItems = ref([]);
const searchText = ref('');

// Kiểm tra xem list hiện tại là Object hay String
const isObjectList = computed(() => {
  return props.items && props.items.length > 0 && typeof props.items[0] === 'object';
});

// Theo dõi thay đổi từ bên ngoài (v-model)
watch(() => props.modelValue, (newVal) => {
  internalValue.value = newVal;
});

// Kiểm tra xem item đã tồn tại trong list chưa
const isExisting = computed(() => {
  if (!searchText.value) return true;
  return props.items && props.items.some(item => {
    const itemVal = typeof item === 'object' ? item[props.optionLabel] : item;
    return itemVal?.toString().toLowerCase() === searchText.value.toLowerCase();
  });
});

// Xử lý khi người dùng nhập/tìm kiếm
const onSearch = (event) => {
  searchText.value = event.query;
  if (!event.query.trim().length) {
    filteredItems.value = [...(props.items || [])];
  } else {
    filteredItems.value = (props.items || []).filter((item) => {
      const itemVal = typeof item === 'object' ? item[props.optionLabel] : item;
      return itemVal?.toString().toLowerCase().includes(event.query.toLowerCase());
    });
  }
};

// Xử lý khi giá trị thay đổi
const onChange = (event) => {
  emit('update:modelValue', event.value);
};

// Xử lý khi nhấn nút Add New
const onAddNew = () => {
  if (!searchText.value || isExisting.value) return;

  let newItem;
  // Quyết định tạo Object hay String dựa trên dữ liệu hiện có hoặc prop optionLabel
  if (isObjectList.value || (props.items.length === 0 && props.optionLabel !== 'label')) {
    newItem = { [props.optionLabel]: searchText.value };
  } else {
    newItem = searchText.value;
  }

  // Cập nhật list items
  const updatedItems = [...props.items, newItem];
  emit('update:items', updatedItems);

  // Chọn luôn item vừa add
  internalValue.value = newItem;
  emit('update:modelValue', newItem);
  emit('add-new', newItem);

  // Reset search
  searchText.value = '';
};
</script>

<style scoped>
.custom-autocomplete-container {
  width: 100%;
  position: relative;
}

:deep(.p-autocomplete) {
  width: 100%;
}
</style>
