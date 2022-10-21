namespace ExerciseProject.Exercise14
{
    public class IntArrayHelper
    {
        public void Sort (int[] arr) {
            int temp;

            for (int i = 0; i <= arr.Length - 1; i++) {
                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[i] > arr[j]) {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public void Reverse (int[] arr) {
            int temp;

            for (int i = 0; i <= arr.Length - 1; i++) {
                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[i] < arr[j]) {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
